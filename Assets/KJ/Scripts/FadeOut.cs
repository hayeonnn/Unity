using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{

    private bool isPlaying;
    private float targetAlpha;
    public Image fadeImg;
    public float fadeRate;

    IEnumerator FadeOutCoroutine(){
        isPlaying = true;
        targetAlpha = 0.00000001f;

        Color fadeColor = fadeImg.color;



        while(fadeColor.a > targetAlpha){

            if(fadeImg.color.a < 0.07f){
                fadeImg.gameObject.SetActive(false);
            }
            // Debug.Log(fadeImg.color.a);
            fadeColor.a = Mathf.Lerp(fadeColor.a, targetAlpha, fadeRate * Time.deltaTime);
            fadeImg.color = fadeColor;
            yield return null;
        }
    }

    private void Awake() {
        fadeImg.gameObject.SetActive(true);
        
        StartCoroutine("FadeOutCoroutine");
    }

}
