using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialTrigger : MonoBehaviour
{
    public GameObject[] triggers;
    public Animator tutoAnim_1;
    public Animator tutoAnim_2;

    private void Awake() {

    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            Debug.Log("트리거 발동");
            tutoAnim_1.SetBool("isOpen", true);
        }
        
    }
}
