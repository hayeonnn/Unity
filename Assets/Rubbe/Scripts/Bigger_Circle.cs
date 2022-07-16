using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bigger_Circle : MonoBehaviour
{
    float time;

    // Update is called once per frame
    void Update()
    {
        transform.localScale = Vector3.one * (1 + time);
        time += Time.deltaTime * 30;
        if (time > 30f)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
    }
}
