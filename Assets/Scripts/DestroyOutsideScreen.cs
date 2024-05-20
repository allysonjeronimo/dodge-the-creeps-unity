using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutsideScreen : MonoBehaviour
{

    private Vector2 screenBounds;
    private float halfWidth;
    private float halfHeight;
    [SerializeField]
    private float offset = 2f;

    private void Start()
    {
        this.screenBounds = Camera.main.ScreenToWorldPoint(
            new Vector3(
                Screen.width,
                Screen.height,
                Camera.main.transform.position.z
                )
            );

        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        halfWidth = renderer != null ? renderer.bounds.size.x / 2f : 0f;
        halfHeight = renderer != null ? renderer.bounds.size.y / 2f : 0f;
    }

    
    private void LateUpdate()
    {
        bool isOutsideOnRight = this.transform.position.x > screenBounds.x + halfWidth + offset;
        bool isOutsideOnLeft = this.transform.position.x < -screenBounds.x - halfWidth - offset;
        bool isOutsideOnTop = this.transform.position.y > screenBounds.y + halfHeight + offset;
        bool isOutsideOnBottom = this.transform.position.y < -screenBounds.y - halfHeight - offset;

        if (isOutsideOnTop || isOutsideOnRight || isOutsideOnBottom || isOutsideOnLeft)
        {
            Destroy(this.gameObject);
        }
    } 

    /*
    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
    */
}
