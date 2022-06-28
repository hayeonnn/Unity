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
    private float targetAlpha;
    public float fadeRate;
    private bool isPlaying = false;

    public void SetActiveDialouge(){
        soulweaponDialogue.gameObject.SetActive(true);
    }
    public void SetFalseDialogue(){
        soulweaponDialogue.gameObject.SetActive(false);
    }

    IEnumerator FadeIn(int sceneNumber){
        isPlaying = true;
        
        fadeIntCanvas.sortingOrder = 1;

        targetAlpha = 1.0f;
        Color fadeColor = fadeImg.color;
        while(Mathf.Abs(fadeColor.a - targetAlpha) > 0.0001f){
            Debug.Log(fadeImg.material.color.a);
            fadeColor.a = Mathf.Lerp(fadeColor.a, targetAlpha, fadeRate * Time.deltaTime);
            fadeImg.color = fadeColor;
            yield return null;
        }
    }



    public void OnClickStory(){
        Debug.Log("이야기 버튼 누름");
        StartCoroutine("FadeIn", 1);
   }

    public void onClickInfo(){
        Debug.Log("내 정보 버튼 누름");
        StartCoroutine("FadeIn", 2);
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
