using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : MonoBehaviour
{
    private Animator animator;
    private string currentAnimationParameter;

    void Start()
    {
        this.animator = GetComponent<Animator>();
        currentAnimationParameter = this.animator.parameters[Random.Range(0, animator.parameters.Length)].name;
        this.animator.SetBool(currentAnimationParameter, true);
    }

    private void OnDestroy()
    {
        this.animator.SetBool(currentAnimationParameter, false);
    }

}
