using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishTrigger : MonoBehaviour
{
    public DialogueTrigger dialogueTrigger;
    public Stage_1_1_Dialogue currentManager;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            Debug.Log("충돌");

            currentManager.SetDialogue(dialogueTrigger.GetDialogue());
            currentManager.StartConversation();
        }
    }
}
