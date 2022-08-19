using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTrigger : MonoBehaviour
{
    public Animator tutoAnim_1;
    public Animator tutoAnim_2;
    public Stack<Animator> tutorialOrder;
    public Animator prevAnimator;
    public bool isDisplay;
    private int coCount = 0;

    private void Awake() {
        tutorialOrder = new Stack<Animator>();

        tutorialOrder.Push(tutoAnim_2);
        tutorialOrder.Push(tutoAnim_1);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            if(tutorialOrder.Count == 0){
                Debug.Log("Stack empty");
                return;
            }
            Debug.Log("Triggered");
            StartCoroutine(WaitTip());            

        }
        
    }
    
    IEnumerator WaitTip(){
        Animator currentAnimator = tutorialOrder.Pop();

        currentAnimator.SetBool("isOpen", true);
        coCount++;
        Debug.Log("코루틴 호출된 수" + coCount);
        isDisplay = true;
        yield return new WaitForSeconds(3f);

        isDisplay = false;
        currentAnimator.SetBool("isOpen", false);

    }

}
