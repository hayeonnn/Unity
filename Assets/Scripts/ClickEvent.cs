using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        text.text = "�;�, ���ɾ��༭ �⻵!";
        Invoke("falsePanel",5.0f);
    }

    void falsePanel()
    {
        talkPanel.SetActive(false);
    }

}
