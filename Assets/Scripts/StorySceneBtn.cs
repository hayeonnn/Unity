using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StorySceneBtn : MonoBehaviour
{
    public GameObject summary;
    public void clickToMain()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void clickToSetting()
    {
        SceneManager.LoadScene("SettingScene");
    }
    public void clickToClose()
    {
        summary.SetActive(false);
    }

}
