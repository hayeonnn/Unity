using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMonsterAction : MonoBehaviour {
    private Animator anim;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rigid;
    public int nextMove;
    enum States{
        idle = 0,
        move = 1,
        jump = 2
    }

    private void Awake() {
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
        Invoke("Think", 2f);
    }

    private void FixedUpdate() {
        // Move
        if(anim.GetInteger("AnimState") == 1)
            rigid.velocity = new Vector2(nextMove, rigid.velocity.y);
        if(nextMove == 0){
            anim.SetInteger("AnimState", (int)States.idle);
        }
        // Platform check
        Vector2 frontVector = new Vector2(rigid.position.x + nextMove * 0.3f, + rigid.position.y);
        RaycastHit2D rayHit = Physics2D.Raycast(frontVector, Vector3.down, 1, LayerMask.GetMask("Platform"));
        Debug.DrawRay(frontVector, Vector3.down, new Color(0, 1, 0));
        if(rayHit.collider == null){
            Turn();
        }
        
    }
    public void Think(){
        nextMove = Random.Range(-1, 2);
        float nextThinkTime = Random.Range(2f, 4f);

       anim.SetInteger("AnimState", (int)States.move);

        // Flip sprite
        if(nextMove != 0)
            spriteRenderer.flipX = nextMove == 1;

        Invoke("Think", nextThinkTime);
    }

    public void Turn(){
        nextMove = nextMove * -1;
        spriteRenderer.flipX = nextMove == 1;

        CancelInvoke("Think");
        Invoke("Think", 2f);
    }
}
