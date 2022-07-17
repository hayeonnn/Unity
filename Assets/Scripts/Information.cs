using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Information : MonoBehaviour {

    #region Text Variable
    public Text nickname;
    public Text weaponName;
    public Text weaponLevel;
    public Text attributeName;
    public Text atkPoint;
    public Text defPoint;
    public Text stoneValue;
    public Text tokenValue;

    #endregion

    public Image attributeImg;
    public Image[] hearts;
    public Button prevButton;



    private void Awake() {
        // if this scene loaded, then update user information
        nickname.text = "닉네임최대10글자로";
        weaponName.text = "한손검";
        stoneValue.text = "111222";
        tokenValue.text = "12";
        attributeName.text = "불속성";
        atkPoint.text = "1";
        defPoint.text = "121";
        
    }

    public void onClickPrevButton(){
        SceneManager.LoadScene(0);
    }
}
