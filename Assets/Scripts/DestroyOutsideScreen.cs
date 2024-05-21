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
        if(TryGetComponent<Boundaries>(out var boundaries))
        {
            screenBounds = boundaries.ScreenBounds;
            halfWidth = boundaries.Size.x / 2f;
            halfHeight = boundaries.Size.y / 2f;
        }
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
