using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogText;
    private Queue<string> sentences;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialog(Dialog dialog){
        sentences.Clear();

        nameText.text = dialog.name;

        foreach(string sentence in dialog.sentences){
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence(){
        if(sentences.Count == 0){
            EndDialog();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogText.text = sentence;
    }

    public void EndDialog(){
        Debug.Log("End Dialog");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
