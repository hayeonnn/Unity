using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    public Text soulweaponDialogue;
    public Image fadeImg;
    public Canvas fadeIntCanvas;
    public Image circleImg;
    private float targetAlpha;
    public float fadeRate;
    private bool isPlaying = false;
    private float targetCircleScale = 450f;


    public void SetActiveDialouge(){
        soulweaponDialogue.gameObject.SetActive(true);
    }
    public void SetFalseDialogue(){
        soulweaponDialogue.gameObject.SetActive(false);
    }

    IEnumerator FadeIn(){
        isPlaying = true;
        
        fadeIntCanvas.sortingOrder = 1;

        targetAlpha = 1.0f;
        Color fadeColor = fadeImg.color;
        while(Mathf.Abs(fadeColor.a - targetAlpha) > 0.0001f){
            Debug.Log(fadeImg.color.a);
            fadeColor.a = Mathf.Lerp(fadeColor.a, targetAlpha, fadeRate * Time.deltaTime);
            fadeImg.color = fadeColor;
            yield return null;
        }
    }

    IEnumerator CircleFadeIn(){

        yield return null;
    }

    private void Update() {
        if(fadeImg.color.a > 0.99f){
            StopCoroutine("FadeIn");
            isPlaying = false;
            SceneManager.LoadScene(1);
        }
    }



    public void OnClickStory(){
        Debug.Log("이야기 버튼 누름");
        StartCoroutine("FadeIn");
   }

    public void onClickInfo(){
        Debug.Log("내 정보 버튼 누름");
        StartCoroutine("FadeIn");
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
    }

}
