using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionSceneBtn : MonoBehaviour
{
    public void clickToStory()
    {
        SceneManager.LoadScene("StoryMap");
    }
}
