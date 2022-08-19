using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class btnPlay : MonoBehaviour
{
    // Start is called before the first frame update
    public string stageName;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SceneChage()
    {
        if (stageName == "1_1")
        {
            SceneManager.LoadScene("Stage_1_1");
        }
    }
}
