using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenBounds : MonoBehaviour
{
    private Vector2 screenBounds;
    private float halfWidth;
    private float halfHeight;

    void Start()
    {
        /**
         * Obtem as dimensões da tela em World Point a partir do Screen Size.
         * O que corresponde a metade, já que em World Point a origem da tela é o centro.
         * Ex: Uma tela de 8x6un -> 4x3
         * */
        this.screenBounds = Camera.main.ScreenToWorldPoint(
            new Vector3(
                Screen.width,
                Screen.height,
                Camera.main.transform.position.z
                )
            );

        SpriteRenderer renderer = this.GetComponent<SpriteRenderer>();

        if(renderer != null)
        {
            halfWidth = renderer.bounds.size.x / 2f;
            halfHeight = renderer.bounds.size.y / 2f;
        }
    }

    void LateUpdate()
    {
        // Clamp garante que o valor estará sempre entre os dois informados (screenBounds)
        Vector3 newPosition = this.transform.position;

        newPosition.x = Mathf.Clamp(newPosition.x, screenBounds.x * -1 + halfWidth, screenBounds.x - halfWidth);
        newPosition.y = Mathf.Clamp(newPosition.y, screenBounds.y * -1 + halfHeight, screenBounds.y - halfHeight);

        this.transform.position = newPosition;
    }
}
