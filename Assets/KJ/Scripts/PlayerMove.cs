using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator animator;
    
    public float maxSpeed;
    public float jumpPower;

    private void Awake() {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void Update() {
        // Stop Speed
        if(Input.GetButtonUp("Horizontal"))
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);
        
        // Jump
        if(Input.GetButtonDown("Jump") && !animator.GetBool("isJumping")){
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            animator.SetBool("isJumping", true);
        }



        // Direction Sprite
        if(Input.GetButton("Horizontal"))
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;

        // Animation
        if(Mathf.Abs(rigid.velocity.x) <= 0.3f)
            animator.SetBool("isWalking", false);
        else
            animator.SetBool("isWalking", true);
    }
    private void FixedUpdate() {
        float h = Input.GetAxisRaw("Horizontal");
        // Move Speed
        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);
        
        // Right Max Speed
        if(rigid.velocity.x >= maxSpeed){
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        }
        // Left Max Speed
        else if(rigid.velocity.x <= maxSpeed * (-1)){
            rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y);
        }

        // Landing platform

        if(rigid.velocity.y < 0){
            RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector3.down, 1, LayerMask.GetMask("Platform"));

            Debug.DrawRay(rigid.position,Vector3.down, new Color(0, 1, 0));
            if(rayHit.collider != null){
                if(rayHit.distance < 0.5f){
                    animator.SetBool("isJumping", false);
                }
            }

        }
    }


    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Enemy"){
            // Attack
            if(rigid.velocity.y < 0 && transform.position.y > other.transform.position.y){

            }

        else
            OnDamaged(other.transform.position);
        }
    }


    private void OnAttack(Transform enemy){

        // Enemy Die
        EnemyMove enemyMove = enemy.GetComponent<EnemyMove>();
        // enemyMove.OnDamged();
    }

    private void OnDamaged(Vector2 targetPos){
        // Change Layer
        gameObject.layer = 9;

        // View Alpha
        spriteRenderer.color = new Color(1, 1, 1, 0.4f);

        // Reaction Force
        int dirc = transform.position.x - targetPos.x > 0 ? 1 : -1;
        rigid.AddForce(new Vector2(dirc, 1) * 7, ForceMode2D.Impulse);

        // Animation
        animator.SetTrigger("doDamaged");

        Invoke("OffDamaged", 2);
    }

    private void OffDamaged(){
        gameObject.layer = 8;

        spriteRenderer.color = new Color(1, 1, 1, 1);
    }
}
