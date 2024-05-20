using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundaries : MonoBehaviour
{
    private Vector2 screenBounds;
    private Vector2 size;

    public Vector2 ScreenBounds {  get { return screenBounds; } }
    public Vector2 Size { get { return size; } }

    void Awake()
    {
        this.screenBounds = Camera.main.ScreenToWorldPoint(
            new Vector3(
                Screen.width, 
                Screen.height, 
                Camera.main.transform.position.z
                )
            ); 
        
        if(TryGetComponent<SpriteRenderer>(out var renderer))
        {
            size = renderer.bounds.size;
        }
    }
}
