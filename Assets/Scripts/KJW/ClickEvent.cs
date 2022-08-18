using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ClickEvent : MonoBehaviour
{
    public GameObject talkPanel;
    public Text text;
    void Start()
    {
        talkPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void onClickObj()
    {
        talkPanel.SetActive(true);
        text.text = "¿Í¾Æ, ¸»°É¾îÁà¼­ ±â»µ!";
        Invoke("falsePanel",5.0f);
    }

    public void clickToStory()
    {
        SceneManager.LoadScene("StoryMap");
    }

    void falsePanel()
    {
        talkPanel.SetActive(false);
    }

}
