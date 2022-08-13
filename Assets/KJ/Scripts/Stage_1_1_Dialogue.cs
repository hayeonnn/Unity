using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BaseDialogue;
using UnityEngine.UI;

public class Stage_1_1_Dialogue : DialogueManager
{

    public override void Awake()
    {
        base.Awake();
    }

    public override void Update(){  
        Debug.Log(centreTextQueue.Count);
        if(dialogue_running && skip){
            SkipDialogue(currentSentence);
        }
        if(isFadeOutOver){
            isFadeOutOver = false;
        }
        
    }


    public override void DisplayNextCentreText()
    {  
        if(centreTextQueue.Count == 0){
            Debug.Log("남아있는게 없다");
            return;
        }
        string centreText = centreTextQueue.Dequeue();
        centreField.text = centreText;
        
        StartCoroutine(FADEIN);
    }

    public override void DisplayNextSentence(){
        
        // Sentence Elements를 다 Out 하고 남은게 없을 때
        if(sentences.Count == 0){
            Debug.Log("없음");
            EndDialogue();
            return;
        }
        // 글자 출력 중 클릭 할 때 스킵 활성화
        if(dialogue_running){
            boxButton.GetComponent<Button>().interactable = false;
            StartCoroutine("ButtonDelay");
            skip = true;
            return;
        }
        // 출력이 다 되었고, 이 함수 호출 하면 다음 dialogue로 넘어감
        else if(!skip && !dialogue_running){
            string sentence = sentences.Dequeue();
            currentSentence = sentence;

            StopAllCoroutines();
            StartCoroutine(TYPESENTENCE, sentence);
        }
        if(sentences.Count == 4){
            showImg.GetComponent<Image>().sprite = nextImg;
            // showImg.color = new Color(1, 1, 1, 1);
        }

        if(sentences.Count == 3){
            Debug.Log("중앙에 나와야됨");
            this.DisplayNextCentreText();
        }
    }

}
