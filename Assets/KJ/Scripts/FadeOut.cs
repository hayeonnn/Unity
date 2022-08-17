using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{

    public bool isPlaying;
    private float targetAlpha;
    public Image fadeImg;
    public float fadeRate;
    public bool isInGame;
    public bool isFadeOutOver;

    public IEnumerator FadeOutCoroutine(){
        isPlaying = true;
        targetAlpha = 0.00000001f;

        Color fadeColor = fadeImg.color;



        while(fadeColor.a > targetAlpha){

            if(fadeImg.color.a < 0.07f){
                fadeImg.gameObject.SetActive(false);
                isPlaying = false;
                isFadeOutOver = true;
                Debug.Log("Fade Out is over");
                StopCoroutine("FadeOutCoroutine");
            }
            
            // Debug.Log(fadeImg.color.a);
            fadeColor.a = Mathf.Lerp(fadeColor.a, targetAlpha, fadeRate * Time.deltaTime);
            fadeImg.color = fadeColor;
            yield return null;
        }
    }

    private void Awake() {
        if(fadeImg == null){
            return;
        }
        if(isInGame){
            return;
        }
        fadeImg.gameObject.SetActive(true);
        
        StartCoroutine("FadeOutCoroutine");
    }

    public void StartFadeOut(){
        Debug.Log("Fade Out: " + fadeImg);
        StartCoroutine("FadeOutCoroutine");
    }

}
