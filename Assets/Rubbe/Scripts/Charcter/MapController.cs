using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public GameObject particle;
    public static int isGet;
    // Start is called before the first frame update
    void Start()
    {
        isGet = 0;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isGet = 1;
            particle.SetActive(false);
            Debug.Log("get");
        }
    }
}
