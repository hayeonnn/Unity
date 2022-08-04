using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 3.0f;
    public float jumpPower;
    Vector2 movement = new Vector2();
    Rigidbody2D rigid;

    bool isJump = false;

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
        rigid = GetComponent<Rigidbody2D>();
        rend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateState();

        if (Input.GetButtonDown("Jump") && isJump == false)
        {
            isJump = true;
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }
    }

    private void FixedUpdate()
    {
        MoveCharcter();

        if (rigid.velocity.y < 0)
        {
            Debug.DrawRay(rigid.position, Vector3.down, new Color(0, 1, 0));
            RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector3.down, 1, LayerMask.GetMask("Platform"));
            if (rayHit.collider != null)
            {
                if (rayHit.distance < 0.5f)
                {
                    isJump = false;
                }
            }
        }
    }

    private void MoveCharcter()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        //movement.y = Input.GetAxisRaw("Vertical");

        movement.Normalize();

        //rigid.velocity = movement * movementSpeed;

        Vector2 vel = rigid.velocity;
        vel.x = movement.x * movementSpeed;
        rigid.velocity = vel;

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
