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

    IEnumerator FadeOutCoroutine(int sceneNumber){
        isPlaying = true;
        
        targetAlpha = 1.0f;
        Color fadeColor = fadeImg.color;
        while(Mathf.Abs(fadeColor.a - targetAlpha) < 0.0001f){
            Debug.Log(fadeImg.color.a);
            fadeColor.a = Mathf.Lerp(fadeColor.a, targetAlpha, fadeRate * Time.deltaTime);
            fadeImg.color = fadeColor;
            yield return null;
        }
    }

    private void Awake() {
        StartCoroutine("FadeOutCoroutine");
    }
}
