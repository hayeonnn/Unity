using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroySelf", 5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.right = GetComponent<Rigidbody2D>().velocity;

    }

    void DestroySelf()
    {
        Destroy(gameObject);
    }

}
