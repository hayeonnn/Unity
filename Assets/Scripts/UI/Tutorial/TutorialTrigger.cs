using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialTrigger : MonoBehaviour
{
    public GameObject[] triggers;
    public Animator tutoAnim_1;
    public Animator tutoAnim_2;
    public Stack<Animator> tutorialOrder;
    public Animator currentAnimator;

    private void Awake() {
        tutorialOrder = new Stack<Animator>();

        tutorialOrder.Push(tutoAnim_2);
        tutorialOrder.Push(tutoAnim_1);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            Debug.Log("트리거 발동");
            currentAnimator = tutorialOrder.Pop();

            currentAnimator.SetBool("isOpen", true);

            StartCoroutine("WaitTip");
            

        }
        
    }
    
    IEnumerator WaitTip(){

        yield return new WaitForSeconds(2f);

        currentAnimator.SetBool("isOpen", false);

        StopCoroutine("WaitTip");
    }
}
