using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    public Text CentreText;
    private Queue<string> sentences;

    private void Awake() {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue){
        Debug.Log("Starting conversation with " + dialogue.name[0]);

        nameText.text = dialogue.name[0];
        sentences.Clear();

        foreach (string sentence in dialogue.playerSentences){
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
        
    }

    public void DisplayNextSentence(){
        if(sentences.Count == 0){
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
    }

    public void EndDialogue(){
        Debug.Log("End of conversation");
    }
}
