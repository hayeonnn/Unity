using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Close_Open_UI : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject targetUI;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CloseTargetUI()
    {
        targetUI.SetActive(false);
    }

    public void OpenTargetUI()
    {
        targetUI.SetActive(true);
    }
}
