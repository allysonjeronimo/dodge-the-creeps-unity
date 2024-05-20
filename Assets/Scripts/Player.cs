using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed = 6f;
    private Vector2 currentVelocity;
    private Animator animator;
    [SerializeField]
    private AudioClip deathAudio;

    void Start()
    {
        this.animator = GetComponent<Animator>();
        this.transform.position = new Vector3(0f, -2f, 0f);
    }

    void Update()
    {
        currentVelocity = Vector2.zero;
        Move();
        UpdateAnimations();
        UpdateFlip();
    }

    private void Move()
    {
        float inputHorizontal = Input.GetAxisRaw("Horizontal");
        float inputVertical = Input.GetAxisRaw("Vertical");

        if (inputHorizontal > 0f)
        {
            currentVelocity.x = 1f;
        }
        if (inputHorizontal < 0f)
        {
            currentVelocity.x = -1f;
        }
        if (inputVertical > 0f)
        {
            currentVelocity.y = 1f;
        }
        if (inputVertical < 0f)
        {
            currentVelocity.y = -1f;
        }


        if (currentVelocity.magnitude > 0f)
        {
            currentVelocity = currentVelocity.normalized;
        }

  
        this.transform.Translate(currentVelocity * speed * Time.deltaTime);
    }

    private void UpdateAnimations()
    {
        animator.SetBool("walk", currentVelocity.x != 0f ? true : false);
        animator.SetBool("up", currentVelocity.y != 0f ? true : false);
    }

    private void UpdateFlip()
    {
        float scaleX = currentVelocity.x < 0f ? -1f : 1f;
        float scaleY = currentVelocity.y < 0f ? -1f : 1f;

        this.transform.localScale = new Vector3(scaleX, scaleY, this.transform.localScale.z);

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Mob"))
        {
            Destroy(this.gameObject);
            GameManager.Instance.GameOver();
            AudioManager.Instance.Play(deathAudio);
        }
    }
}
