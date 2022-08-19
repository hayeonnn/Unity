using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Âü°í: https://velog.io/@cedongne/Unity-2D-%EC%B9%B4%EB%A9%94%EB%9D%BC-%EB%B2%94%EC%9C%84-%EC%A0%9C%ED%95%9C%ED%95%98%EA%B8%B0

public class CameraManager : MonoBehaviour
{
    float height;
    float width;
    GameObject player; 
    Vector2 center = new Vector2(-120.8f,-10);

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        height = Camera.main.orthographicSize;
        width = height * Screen.width / Screen.height;
    }
    void FixedUpdate()
    {
        if(player != null)
        {
            float lx = 3840 - width;
            float clampX = Mathf.Clamp(transform.position.x, center.x - lx, center.x + lx);
            float ly = 540 - height;
            float clampY = Mathf.Clamp(transform.position.y, center.y - ly, center.y + ly);

            transform.position = new Vector3(clampX, clampY, -10f);
        }
    }
}
