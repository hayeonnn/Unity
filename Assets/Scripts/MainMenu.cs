using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    public Canvas fadeInCanvas;
    public Text soulweaponDialogue;
    public Image fadeImg;
    public Image circleImg;
    private float targetAlpha;
    public float fadeRate;
    private bool isPlaying = false;
    private Vector2 targetCircleSize;
    // 0: Topdown, 1: Platformer
    private int menuOrder;

    // Divided functions for Invoke()
    public void SetActiveDialouge(){
        soulweaponDialogue.gameObject.SetActive(true);
    }
    public void SetFalseDialogue(){
        soulweaponDialogue.gameObject.SetActive(false);
    }

    IEnumerator FadeIn(){
        isPlaying = true;
        
        fadeInCanvas.sortingOrder = 1;

        targetAlpha = 1.0f;
        Color fadeColor = fadeImg.color;
        // Up BlackScreen Alpha value via lerp
        while(Mathf.Abs(fadeColor.a - targetAlpha) > 0.0001f){
            // Debug.Log(fadeImg.color.a);
            fadeColor.a = Mathf.Lerp(fadeColor.a, targetAlpha, fadeRate * Time.deltaTime);
            fadeImg.color = fadeColor;
            yield return null;
        }
    }

    IEnumerator CircleFadeIn(){
        
        isPlaying = true;

        fadeInCanvas.sortingOrder = 1;
        // SetActive 대신 Alpha 0로 안보이게 했던 Circle을 보여주기
        Color tempColor = circleImg.color;
        tempColor.a = 1;
        circleImg.color = tempColor;

        targetCircleSize = new Vector2(4000f, 4000f);

        Vector2 target = circleImg.rectTransform.sizeDelta;

        // Fill Canavas fully
        while(target != targetCircleSize){
            circleImg.rectTransform.sizeDelta = Vector2.Lerp(circleImg.rectTransform.sizeDelta, targetCircleSize, fadeRate * Time.deltaTime);
            yield return null;
        }
    }

    private void Update() {
        
        // Mathf.Lerp() Can't reach target value. so written like these
        if(fadeImg.color.a > 0.99f){
            StopCoroutine("FadeIn");
            isPlaying = false;
            SceneManager.LoadScene(menuOrder);
        }
        if(circleImg.rectTransform.sizeDelta.x >= 3800) {
            StopCoroutine("CircleFadeIn");
            isPlaying = false;
            SceneManager.LoadScene(menuOrder);
        }

    }



    public void OnClickStory(){
        Debug.Log("이야기 버튼 누름");
        if(!isPlaying){
            menuOrder = 1;
            StartCoroutine("FadeIn");

        }
   }

    public void onClickInfo(){
        Debug.Log("내 정보 버튼 누름");
        if(!isPlaying){
            menuOrder = 4;
            StartCoroutine("CircleFadeIn");
        }
    }
    public void onClickInteraction(){
        Debug.Log("소울웨폰 인연 시스템");
    }
    
    public void onClickSoulweapon(){
        Debug.Log("소울웨폰 누름");
        
        SetActiveDialouge();
        Invoke("SetFalseDialogue", 2f);
    }

    public void onClickSetting(){
        Debug.Log("설정 버튼 누름");
        SceneManager.LoadScene(3);
    }

    public void onClickCostumeButton(){
        Debug.Log("코스튬 버튼 누름");
        SceneManager.LoadScene(5);
    }
}
