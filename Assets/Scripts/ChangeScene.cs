using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string TargetScene;

    public float delayTime;

    public void SceneChange()
    {
        SceneManager.LoadScene(TargetScene);
    }
    public void SceneChange_AfterDelay()
    {
        Invoke("SceneChange", delayTime);
    }
}
