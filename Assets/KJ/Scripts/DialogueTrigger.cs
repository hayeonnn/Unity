using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BaseDialogue;
public class DialogueTrigger : MonoBehaviour
{
    public Dialogue prologueScript;
    public GameObject DialogueBox;
    public static bool isOver;
    public static bool isPrologue;

    private void Start() {
        DialogueBox.SetActive(false);
        if(isPrologue){
            InitCentreText();
        }
        else if(!isPrologue) {
            InitCentreText();
            isOver = true;
        }
        
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
