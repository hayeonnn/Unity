using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 3.0f;
    Vector2 movement = new Vector2();
    Rigidbody2D rigidbody2D;

    SpriteRenderer rend;

    Animator animator;
    string animationsState = "AnimState";

    enum States
    {
        idle = 0,
        move = 1,
        jump = 2
    }
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        rend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateState();
    }

    private void FixedUpdate()
    {
        MoveCaharcter();
    }

    private void MoveCaharcter()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        //movement.y = Input.GetAxisRaw("Vertical");

        movement.Normalize();

        rigidbody2D.velocity = movement * movementSpeed;
    }

    private void UpdateState()
    {
        if (movement.x > 0)
        {
            rend.flipX = true;
            animator.SetInteger(animationsState, (int)States.move);
        }
        else if(movement.x < 0)
        {
            rend.flipX = false;
            animator.SetInteger(animationsState, (int)States.move);
        }
        else
        {
            animator.SetInteger(animationsState, (int)States.idle);
        }
    }
}
