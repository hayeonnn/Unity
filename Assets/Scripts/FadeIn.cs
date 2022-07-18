using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{

    public static bool isPlaying;
    private float targetAlpha;
    public Image fadeImg;
    public float fadeRate;

    IEnumerator FadeInCoroutine(){
        isPlaying = true;
        targetAlpha = 1.0f;

        Color fadeColor = fadeImg.color;



        while(Mathf.Abs(fadeColor.a - targetAlpha) > 0.0001f){
            if(fadeImg.color.a >= 0.96f){
                isPlaying = false;
                break;
            }
            // Debug.Log(fadeImg.color.a);
            fadeColor.a = Mathf.Lerp(fadeColor.a, targetAlpha, fadeRate * Time.deltaTime);
            fadeImg.color = fadeColor;
            yield return null;
        }
    }

    public void onClickPrevButton(){
        Debug.Log("This is FadeIn.cs");

        fadeImg.gameObject.SetActive(true);
        

        StartCoroutine("FadeInCoroutine");
    }

}
