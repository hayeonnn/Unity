using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour{

    Rigidbody2D rigid;
    Animator animator;
    SpriteRenderer spriteRenderer;
    public int nextMove;

    private void Awake() {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        Invoke("Think", 5);
    }

    private void FixedUpdate() {
        // Move
        rigid.velocity = new Vector2(nextMove, rigid.velocity.y);

        // Platform check
        Vector2 frontVector = new Vector2(rigid.position.x + nextMove * 0.3f, + rigid.position.y);
        RaycastHit2D rayHit = Physics2D.Raycast(frontVector, Vector3.down, 1, LayerMask.GetMask("Platform"));
        Debug.DrawRay(frontVector, Vector3.down, new Color(0, 1, 0));
        if(rayHit.collider == null){
            Turn();
        }
    }

    // Recursion
    public void Think(){
        // MaxExclusive not include max range.
        // Set next active
        nextMove = Random.Range(-1, 2);
        float nextThinkTime = Random.Range(2f, 5f);

        // Sprite animation
        animator.SetInteger("WalkSpeed", nextMove);
        // Flip sprite
        if(nextMove != 0)
            spriteRenderer.flipX = nextMove == 1;

        // Recursive 
        Invoke("Think", nextThinkTime);

    }

    public void Turn(){
        nextMove = nextMove * -1;
        spriteRenderer.flipX = nextMove == 1;
        
        CancelInvoke();
        Invoke("Think", 2);
    }

    public void OnDamaged(){
        // Sprite Alpha

        // Sprite Flip Y

        // Colider Disable

        // Die Effect Jump

        // Destory
    }
}
