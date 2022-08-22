using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BaseDialogue;
using UnityEngine.UI;

public class Stage_1_1_Dialogue : DialogueManager
{
    public FadeIn fadeIn;
    public FadeOut fadeOut;
    private Texture2D starRainImg;
    private Texture2D ruinBuildingImg;
    private Texture2D escapeImg;
    private Texture2D theStone;
    private Texture2D trio;
    private Texture2D clearImg;
    public GameObject[] inGameObjects;
    public GameObject mainCamera;
    public GameObject finishTrigger;

    Sprite starRainSprite;
    Sprite ruinBuildingSprite;
    Sprite escapeSprite;
    Sprite theStoneSprite;
    Sprite trioSprite;
    Sprite clearSprite;
    private bool endPrologue;
    private bool lastConversation;
    // DialogueBox onClick() parameter 
    private UnityEngine.Events.UnityAction buttonCallback;
    private bool isChangedQueue = false;
    
    private Vector3 tmpCentrePosition;
    public override void Awake()
    {
        starRainImg = Resources.Load<Texture2D>("Sprites/star_rain");
        ruinBuildingImg = Resources.Load<Texture2D>("Sprites/ruinBuilding");
        escapeImg = Resources.Load<Texture2D>("Sprites/escape");
        theStone = Resources.Load<Texture2D>("Sprites/the_stone");
        trio = Resources.Load<Texture2D>("Sprites/trio");
        clearImg = Resources.Load<Texture2D>("Sprites/clear_scene");

        starRainSprite = Sprite.Create(starRainImg, new Rect(0, 0, starRainImg.width, starRainImg.height), Vector2.zero);
        ruinBuildingSprite = Sprite.Create(ruinBuildingImg, new Rect(0, 0, ruinBuildingImg.width, ruinBuildingImg.height), Vector2.zero);
        escapeSprite = Sprite.Create(escapeImg, new Rect(0, 0, escapeImg.width, escapeImg.height), Vector2.zero);
        theStoneSprite = Sprite.Create(theStone, new Rect(0, 0,theStone.width, theStone.height), Vector2.zero);
        trioSprite = Sprite.Create(trio, new Rect(0, 0, trio.width, trio.height), Vector2.zero);
        clearSprite = Sprite.Create(clearImg, new Rect(0, 0, clearImg.width, clearImg.height), Vector2.zero);
        
        endPrologue = false;
        lastConversation = false;

        fadeIn = GetComponent<FadeIn>();
        fadeOut = GetComponent<FadeOut>();
        fadeIn.fadeImg = showImg;
        fadeOut.fadeImg = showImg;
        base.Awake();

        tmpCentrePosition = centreField.transform.position;

        foreach (GameObject objects in inGameObjects){
            objects.gameObject.SetActive(false);
        }
    }

    public override void Update(){
        if(dialogue_running && skip){
            SkipDialogue(currentSentence);
        }
        if(isFadeOutOver && !endPrologue){
            boxButton.gameObject.SetActive(true);
            isFadeOutOver = false;
        }
        if(fadeIn.isFadeInOver && sentences.Count == 0 && endPrologue && !lastConversation){
            if(!isChangedQueue){
                Debug.Log("프롤로그 끝");
                showImg.gameObject.SetActive(false);
                nextImg.gameObject.SetActive(false);
                boxButton.gameObject.SetActive(false);
                fadeIn.isFadeInOver = false;
                
                Debug.Log(tmpCentrePosition);
                tmpCentrePosition.y += 200;

                centreField.transform.position = tmpCentrePosition;

                this.DisplayNextCentreText();

            }
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
            if(dialogue_running){
                SkipDialogue(currentSentence);
                return;
            }
            Debug.Log("없음");
            showImg.gameObject.SetActive(true);
            fadeIn.StartFadeIn();
            boxButton.gameObject.SetActive(false);

            EndDialogue();
            endPrologue = true;
            
            foreach (GameObject objects in inGameObjects){
                objects.gameObject.SetActive(true);
            }

            mainCamera.transform.SetParent(inGameObjects[0].transform);
            
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
            continueText();
        }
        
        // 해당 대사 때 페이드 인아웃 버튼 딜레이 넣어서 해결
        if(sentences.Count == 9){
            fadeOut.StartFadeOut();
            
            boxButton.GetComponent<Button>().interactable = false;
            StartCoroutine("ButtonDelay");
        }

        if(sentences.Count == 8){
            boxButton.gameObject.SetActive(false);
            
            showImg.gameObject.SetActive(true);
            Debug.Log("중앙에 나와야됨");
            
            fadeIn.StartFadeIn();
            this.DisplayNextCentreText();
        }
        if(sentences.Count == 7){
            fadeIn.isFadeInOver = false;
            fadeOut.StartFadeOut();
            nextImg.sprite = ruinBuildingSprite;
        }
        if(sentences.Count == 5){
            nextImg.sprite = escapeSprite;
        }
        if(sentences.Count == 3){
            nextImg.sprite = theStoneSprite;
        }
        if(sentences.Count == 1){
            nextImg.sprite = trioSprite;
        }
    }


    private Dialogue dialogue;
    public bool isConversation = false;
    public void SetDialogue(Dialogue dialogue){
        this.dialogue = dialogue;
    }
    public void StartConversation(){
        nameText.text = dialogue.name[1];
        if(!isChangedQueue){
            ChangeDialogueQueue();
            showImg.gameObject.SetActive(true);
            boxButton.gameObject.SetActive(true);

        }

        if(conversationQueue.Count == 0){
            boxButton.GetComponent<Button>().interactable = false;
            StartCoroutine("ButtonDelay");

            Debug.Log("대화 끝");
            showImg.gameObject.SetActive(true);
            nextImg.gameObject.SetActive(true);
            playerPortait.gameObject.SetActive(false);
            
            nextImg.sprite = clearSprite;

            returnMap.gameObject.SetActive(true);
            return;
        }

        else {
            if(!isConversation){
                fadeIn.StartHalfFadeIn();
                lastConversation = true;
            }
            Debug.Log("StartConversation 시작");

        
            playerPortait.gameObject.SetActive(true);
            if(dialogue_running){
                boxButton.GetComponent<Button>().interactable = false;
                StartCoroutine("ButtonDelay");
                skip = true;
                return;
            }

            else if(!skip && !dialogue_running){
                continueConversation();
            }

        }
    }


    public void continueText(){
            string sentence = sentences.Dequeue();
            currentSentence = sentence;

            StopAllCoroutines();
            StartCoroutine(TYPESENTENCE, sentence);
    }

    public void continueConversation(){
        string sentence = conversationQueue.Dequeue();
        currentSentence = sentence;

        StopAllCoroutines();
        StartCoroutine(TYPESENTENCE, sentence);
    }
    
    
    public void ChangeDialogueQueue(){
        Debug.Log(boxButton.GetComponent<Button>().onClick.ToString());
        if(buttonCallback != null){
            boxButton.onClick.RemoveListener(buttonCallback);
            isChangedQueue = true;
        }
        // Debug.Log("갈아치움");

        buttonCallback = () => this.StartConversation();
        
        boxButton.onClick.AddListener(buttonCallback);

    }
}
