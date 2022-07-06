using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public GameObject Btns;
    // Start is called before the first frame update
    void Start()
    {
        Btns.GetComponent<Image>().alphaHitTestMinimumThreshold = 0.1f;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
