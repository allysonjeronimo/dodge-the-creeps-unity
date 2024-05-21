using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Requer componente Boundaries
 **/
public class ScreenBounds : MonoBehaviour
{
    private Vector2 screenBounds;
    private float halfWidth;
    private float halfHeight;

    void Start()
    {
        if (TryGetComponent<Boundaries>(out var boundaries))
        {
            screenBounds = boundaries.ScreenBounds;
            halfWidth = boundaries.Size.x / 2f;
            halfHeight = boundaries.Size.y / 2f;
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
