using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue prologueScript;
    public GameObject DialogueBox;
    public static bool isOver;

    private void Start() {
        DialogueBox.SetActive(false);
        InitCentreText();
        
    }

    private void Update() {
        if(isOver){
            isOver = false;
            DialogueBox.SetActive(true);
            TriggerDialogue();
        }
    }

    public void TriggerDialogue(){
        FindObjectOfType<DialogueManager>().StartDialogue(prologueScript);
    }

    public void InitCentreText(){
        FindObjectOfType<DialogueManager>().StartCentreText(prologueScript);
    }
}
