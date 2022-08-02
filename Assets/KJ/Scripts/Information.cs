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

    List<string> attributeList = new List<string>();
    public List<Sprite> attributeImgList;




    private void Awake() {
        int randNumber = Random.Range(0, 3);
        Debug.Log(randNumber);
        // if this scene loaded, then update user information
        attributeList.Add("무속성");
        attributeList.Add("불속성");
        attributeList.Add("풀속성");
        attributeList.Add("물속성");

        nickname.text = "닉네임최대10글자로";
        weaponName.text = "한손검";
        stoneValue.text = "111222";
        tokenValue.text = "12";
        attributeImg.GetComponent<Image>().sprite = attributeImgList[randNumber];
        attributeName.text = attributeList[randNumber];
        atkPoint.text = "1";
        defPoint.text = "121";
        weaponLevel.text = "10";
        


    }

    public void onClickPrevButton(){
        if(FadeIn.isPlaying == false){
            Debug.Log("isPlaying false");
            SceneManager.LoadScene(0);
        }
    }
}
