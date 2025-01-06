using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float moveSpeed = 5f;

    Vector2 movement;

    public Animator animator;
    public Rigidbody2D rb;

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        DirectionUpdate();

        bool isWalking = movement.x != 0 || movement.y != 0;
        bool isAttack = Input.GetMouseButtonDown(0);

        if (isWalking)
        {
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
        }

        animator.SetBool("IsWalking", isWalking);
        animator.SetBool("IsAttack", isAttack);
        FixedUpdate();
    }

    void DirectionUpdate()
    {
        if (movement.x == -1)
        {
            animator.SetFloat("Direction", 4);
        }
        else if (movement.x == 1)
        {
            animator.SetFloat("Direction", 2);
        }
        else if (movement.y == -1)
        {
            animator.SetFloat("Direction", 1);
        }
        else if (movement.y == 1)
        {
            animator.SetFloat("Direction", 3);
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
