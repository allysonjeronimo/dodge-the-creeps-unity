using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : MonoBehaviour
{
    private Animator animator;
    private string currentAnimationParameter;
    private float speed;
    private float[] speeds = { 4f, 6f };

    void Start()
    {
        this.animator = GetComponent<Animator>();
        currentAnimationParameter = this.animator.parameters[Random.Range(0, animator.parameters.Length)].name;
        this.animator.SetBool(currentAnimationParameter, true);
        this.speed = speeds[Random.Range(0, speeds.Length)];
    }

    private void Update()
    {
        this.transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnDestroy()
    {
        this.animator.SetBool(currentAnimationParameter, false);
    }

}
