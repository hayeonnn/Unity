using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BaseDialogue {
public class DialogueManager : MonoBehaviour
{
    // public DialogueManager(Queue<string> sentences, Queue<string> centreText){
    //     sentences = this.sentences;
    //     centreText = this.centreTextQueue;
    // }
    public Text nameText;
    public Text dialogueText;
    public Text centreField;
    public Image showImg;
    public Image nextImg;
    // public Animator animator;

    [HideInInspector]
    public Queue<string> sentences;
    [HideInInspector]
    public Queue<string> centreTextQueue;
    [HideInInspector]
    public Queue<string> conversationQueue;
    [HideInInspector]
    public const string TYPESENTENCE = "TypeSentence";
    [HideInInspector]
    public const string FADEOUT = "TextFadeOut";
    [HideInInspector]
    public const string FADEIN = "TextFadeIn";
    [HideInInspector]
    public bool dialogue_running = false;
    [HideInInspector]
    public bool skip = false;
    [HideInInspector]
    public string currentSentence;

    public Button boxButton;

    public virtual void Awake() {
        sentences = new Queue<string>();
        centreTextQueue = new Queue<string>();
        conversationQueue = new Queue<string>();
        Color currentColor = centreField.color;
        // 초기 중앙 문구 안보이게 하기
        centreField.color = new Color(currentColor.r, currentColor.g, currentColor.b, 0);
        
    }

    public virtual void Update() {
        Debug.Log(sentences.Count);
        if(dialogue_running && skip){
            SkipDialogue(currentSentence);
        }
        if(isFadeOutOver){
            isFadeOutOver = false;
            DisplayNextCentreText();
        }
    }

    // Dialogue 초기화
    public virtual void StartDialogue(Dialogue dialogue){
        Debug.Log("StartDialogue가 호출됨");

        // animator.SetBool("IsOpen", true);

        nameText.text = dialogue.name[0];         // Speaker field
        sentences.Clear();

        // Dialogue Text Queue에 dialogue.playerSenetences 다 넣기
        foreach (string sentence in dialogue.playerSentences){
            sentences.Enqueue(sentence);
        }
        // DialogueTrigger.Start()로 자동 실행되게 하기
        DisplayNextSentence();
    }

    public virtual void InitConversationQueue(Dialogue dialogue){
        conversationQueue.Clear();

        foreach (string sentence in dialogue.conversationSentences){
            conversationQueue.Enqueue(sentence);
        }
        
    }
    public Text playerName;
    public void SetPlayerName(Dialogue dialogue){
        playerName.text = dialogue.name[1];
    }


    public virtual void DisplayNextSentence(){
        
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

    }
    
    
    

    // 문자 출력 코루틴
    // 초기 dialogueText field를 비움
    // 0.04초 주기로 한 글자씩 출력
    // 출력이 완료 되었으면 dialogue_running을 false로
    IEnumerator TypeSentence(string sentence){
        dialogue_running = true;
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray()){
            dialogueText.text += letter;
            yield return new WaitForSecondsRealtime(0.04f);
        }
        dialogue_running = false;
    }

    IEnumerator ButtonDelay(){
        yield return new WaitForSeconds(0.8f);

        boxButton.GetComponent<Button>().interactable = true;
    }

    // 플레이어가 dialogue 출력 중에 클릭(터치) 했을 때
    // 코루틴 중단 후 dialogueText field를 출력 중인 sentence로 덮어쓰기
    // 한번 스킵하면 변수들을 코루틴 완료 후의 상태로
    public void SkipDialogue(string sentence){
        StopCoroutine(TYPESENTENCE);
        dialogueText.text = sentence;
        dialogue_running = false;
        skip = false;
    }

    public void EndDialogue(){
        // animator.SetBool("IsClose", false);
    }
    
    public virtual void StartCentreText(Dialogue dialogue){
        centreTextQueue.Clear(); // 한번 비우기
        // 중앙 문구 Queue에 dialog.centreText 다 넣기
        foreach (string centreText in dialogue.centreText){
            centreTextQueue.Enqueue(centreText);
        }
        if(DialogueTrigger.isPrologue){
            DisplayNextCentreText();
        }
        else {
            return;
        }
    }

    public virtual void DisplayNextCentreText(){
        if(centreTextQueue.Count == 0){
            Debug.Log("남아있는게 없다");
            DialogueTrigger.isOver = true;
            // Debug.Log(DialogueTrigger.isOver);
            return;
        }
        string centreText = centreTextQueue.Dequeue();
        centreField.text = centreText;
        
        StartCoroutine(FADEIN);
    }


    [HideInInspector]
    public float fadeTime = 2.0f;
    [HideInInspector]
    public bool isFadeOutOver;
    // 사라짐
    IEnumerator TextFadeOut(){
        centreField.color = new Color(centreField.color.r, centreField.color.g, centreField.color.b, 1);
        
        while(centreField.color.a > 0.0f){
            centreField.color = new Color(centreField.color.r, centreField.color.g, centreField.color.b, centreField.color.a - (Time.deltaTime / fadeTime));
            yield return null;
        }
        isFadeOutOver = true;

        if(isFadeOutOver){
            Debug.Log("중앙 문구 Fade I/O 끝");
        }
    }
    // 나타남
    IEnumerator TextFadeIn(){
        centreField.color = new Color(centreField.color.r, centreField.color.g, centreField.color.b, 0);
        while(centreField.color.a < 1.0f){
            centreField.color = new Color(centreField.color.r, centreField.color.g, centreField.color.b, centreField.color.a + (Time.deltaTime / fadeTime));
            yield return null;
        }
        StartCoroutine(FADEOUT);
    }

}

}