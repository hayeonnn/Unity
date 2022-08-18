using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingScript : MonoBehaviour {
   
   public Button confirmButton;
   public Slider soundSlider;


    public void onClickConfirmButton(){
        Debug.Log("You Pressed Confirm Button!");
        float sliderValue = soundSlider.value;
        Debug.Log(sliderValue);
        SceneManager.LoadScene(0);
    }
}