using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    float h;
    float v;
    bool isHorizonMove;
    public float speed;
    Vector2 dirVec;

    Rigidbody2D rigid;
    Animator anim;

    private void Awake() {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update() {
        // Move Value
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
        
        // Check Button Down & Up
        bool hDown = Input.GetButtonDown("Horizontal");
        bool vDown = Input.GetButtonDown("Vertical");
        bool hUp = Input.GetButtonUp("Horizontal");
        bool vUp = Input.GetButtonUp("Vertical");

        // Check Horizontal Move
        if(hDown || vUp){
            isHorizonMove = true;
            Debug.Log("hDown vUp");

        }
        else if(vDown || hUp){
            isHorizonMove = false;
            Debug.Log("vDown hUp");
        }
        else if(hUp || vUp)
            isHorizonMove = h != 0;

        // Animation
        if(anim.GetInteger("hAxisRaw") != h){
            anim.SetBool("isChange", true);
            anim.SetInteger("hAxisRaw", (int)h);
        }
        else if(anim.GetInteger("vAxisRaw") != v){
            anim.SetBool("isChange", true);
            anim.SetInteger("vAxisRaw", (int)v);
        }
        else {
            anim.SetBool("isChange", false);
        }

        // Direction    
        if(vDown && v == 1)
            dirVec = Vector3.up;
        else if(vDown && v == -1)
            dirVec = Vector3.down;
        else if(hDown && h == -1)
            dirVec = Vector3.left;
        else if(hDown && h == 1)
            dirVec = Vector3.right;
        
    }



    private void FixedUpdate() {

        // Move
        Vector2 moveVec = isHorizonMove ? new Vector2(h, 0) : new Vector2(0, v);
        rigid.velocity = moveVec * speed;

        // Ray
        Debug.DrawRay(rigid.position, dirVec * 0.7f, new Color(0, 1, 0));
        
    }
    
}
