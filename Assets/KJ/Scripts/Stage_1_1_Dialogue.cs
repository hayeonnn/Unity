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

    Sprite starRainSprite;
    Sprite ruinBuildingSprite;
    Sprite escapeSprite;
    Sprite theStoneSprite;
    Sprite trioSprite;
    private bool endPrologue;
    public override void Awake()
    {
        starRainImg = Resources.Load<Texture2D>("Sprites/star_rain");
        ruinBuildingImg = Resources.Load<Texture2D>("Sprites/ruinBuilding");
        escapeImg = Resources.Load<Texture2D>("Sprites/escape");
        theStone = Resources.Load<Texture2D>("Sprites/the_stone");
        trio = Resources.Load<Texture2D>("Sprites/trio");


        starRainSprite = Sprite.Create(starRainImg, new Rect(0, 0, starRainImg.width, starRainImg.height), Vector2.zero);
        ruinBuildingSprite = Sprite.Create(ruinBuildingImg, new Rect(0, 0, ruinBuildingImg.width, ruinBuildingImg.height), Vector2.zero);
        escapeSprite = Sprite.Create(escapeImg, new Rect(0, 0, escapeImg.width, escapeImg.height), Vector2.zero);
        theStoneSprite = Sprite.Create(theStone, new Rect(0, 0,theStone.width, theStone.height), Vector2.zero);
        trioSprite = Sprite.Create(trio, new Rect(0, 0, trio.width, trio.height), Vector2.zero);
        
        endPrologue = false;

        fadeIn = GetComponent<FadeIn>();
        fadeOut = GetComponent<FadeOut>();
        fadeIn.fadeImg = showImg;
        fadeOut.fadeImg = showImg;
        base.Awake();
    }

    public override void Update(){  
        Debug.Log(sentences.Count);
        if(dialogue_running && skip){
            SkipDialogue(currentSentence);
        }
        if(isFadeOutOver){
            boxButton.gameObject.SetActive(true);
            isFadeOutOver = false;
        }
        // if(fadeIn.isFadeInOver && endPrologue){
        //     showImg.gameObject.SetActive(false);
        //     nextImg.gameObject.SetActive(false);
        //     fadeIn.isFadeInOver = false;
        // }

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
            if(fadeIn.isFadeInOver){
                endPrologue = true; 
            }
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
        if(sentences.Count == 9){
            fadeOut.StartFadeOut();
        }

        if(sentences.Count == 8){
            boxButton.gameObject.SetActive(false);
            
            showImg.gameObject.SetActive(true);
            Debug.Log("중앙에 나와야됨");
            
            fadeIn.StartFadeIn();
            this.DisplayNextCentreText();
        }
        if(sentences.Count == 7){
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


    public void continueText(){
            string sentence = sentences.Dequeue();
            currentSentence = sentence;

            StopAllCoroutines();
            StartCoroutine(TYPESENTENCE, sentence);
    }

}
