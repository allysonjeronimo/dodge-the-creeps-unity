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
        
        if(TryGetComponent<SpriteRenderer>(out var renderer))
        {
            size = renderer.bounds.size;
        }
    }
}
