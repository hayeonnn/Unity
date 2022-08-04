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
    public float randomX, randomY;
    public Vector2 randMove, nextMove;
    
    private void Awake() {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        isPatrol = true;
        thinkTime = 1f;
        position = transform.position;
        Invoke("PatrolMovement", thinkTime); // 배회하기 함수
    }
    
    private void FixedUpdate() {
        float step = moveSpeed * Time.deltaTime;
        target = player.transform.position;

        betweenDisatance = Vector2.Distance(transform.position, target);
        // Debug.Log(betweenDisatance);
        
        // 너무 위로 떠올랐을 때 제약
        if(transform.position.y >= 6f){
            // Debug.Log("Too high");
            Vector2 constraintFly = new Vector2(0, -2);
            rigid.velocity = constraintFly;
        }
        
        // 플레이어와의 거리가 4 이하일 때 (벡터 연산)
        if(betweenDisatance < 6f && isPatrol){
            FoundPlayer(step);
        }

        if(!isPatrol)
            transform.position = Vector2.MoveTowards(transform.position, target, step);

        else {
            transform.position = Vector2.MoveTowards(transform.position, nextMove, moveSpeed * Time.deltaTime);
        }
    }
    // 플레이어와의 거리가 가까울 때 취하는 행동함수
    private void FoundPlayer(float step){
        isPatrol = false;
        anim.SetBool("isPlayerNear", true);
        CancelInvoke("PatrolMovement");
    }

    // 배회 함수
    public void PatrolMovement(){
        randomX = Random.Range(-5, 6);
        randomY = Random.Range(-5, 6);

        randMove = new Vector2(randomX, randomY);
        nextMove = position + randMove;
        
        Invoke("PatrolMovement", thinkTime);
    }
}


// 위에 보이지않는 벽 만들어서 제약 조건

// position.y가 일정 수치 이상으로 올라갈 때 내려가게 제어하기