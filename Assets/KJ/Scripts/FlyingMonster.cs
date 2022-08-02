using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingMonster : MonoBehaviour
{
    Rigidbody2D rigid;
    public GameObject player;
    private Vector2 target;
    private Vector2 position;
    private float betweenDisatance;
    public float moveSpeed;
    private bool isPatrol;
    public float thinkTime;
    Animator anim;
    
    private void Awake() {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        isPatrol = true;
        thinkTime = 1.5f;
        Invoke("PatrolMovement", thinkTime);
    }
    
    private void Update() {
        float step = moveSpeed * Time.deltaTime;
        target = player.transform.position;

        betweenDisatance = Vector2.Distance(transform.position, target);
        Debug.Log(betweenDisatance);
        

        

        if(betweenDisatance < 4f){
            isPatrol = false;
            FoundPlayer(step);
        }
    }

    private void FoundPlayer(float step){
        anim.SetBool("isPlayerNear", true);

        transform.position = Vector2.MoveTowards(transform.position, target, step);
    }

    public void PatrolMovement(){
        float randomX = Random.Range(-1, 4), randomY = Random.Range(-1, 4);
        float speed = 3f * Time.deltaTime;

        Vector2 nextMove = new Vector2(randomX, randomY);
        // Debug.Log(nextMove);
        Vector2 currentVector = rigid.velocity;
        currentVector.x = randomX;
        currentVector.y = randomY;
        
        rigid.velocity = currentVector;
        
        Invoke("PatrolMovement", thinkTime);
    }
}


// 위에 보이지않는 벽 만들어서 제약 조건

// position.y가 일정 수치 이상으로 올라갈 때 내려가게 제어하기