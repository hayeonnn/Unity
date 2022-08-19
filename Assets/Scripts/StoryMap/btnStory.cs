using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnStory : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject btnPlay;
    void Awake()
    {
        btnPlay = GameObject.Find("btnPlay");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeBtnPlay()
    {
        btnPlay.GetComponent<btnPlay>().stageName 
            = gameObject.name.Substring(8, 3);
    }
}
