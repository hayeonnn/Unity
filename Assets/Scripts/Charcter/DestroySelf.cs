using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    // Start is called before the first frame update
    public float DestoryTime;

    void Start()
    {
        Destroy(this.gameObject, DestoryTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
