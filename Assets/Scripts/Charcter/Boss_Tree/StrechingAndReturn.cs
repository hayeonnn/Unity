using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrechingAndReturn : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject StartObject;
    public GameObject EndObject;
    public GameObject DestinationPoint;

    public Vector3 InitialScale;

    float direction;
    void Start()
    {
        InitialScale = transform.localScale;
        direction = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (direction == 1)
        {
            float distance = Vector3.Distance(StartObject.transform.position, EndObject.transform.position);
            transform.localScale = new Vector3(InitialScale.x, distance, InitialScale.z);

            Vector3 middlePoint = (StartObject.transform.position + EndObject.transform.position) / 2f;
            transform.position = middlePoint;

            Vector3 rotationDirection = (EndObject.transform.position - StartObject.transform.position);
            transform.up = rotationDirection;

            EndObject.transform.position = Vector3.MoveTowards(EndObject.transform.position, DestinationPoint.transform.position, 0.3f);
            if (EndObject.transform.position == DestinationPoint.transform.position)
            {
                Invoke("ReverseDirection", 0.3f);
            }
        }
        else if (direction == 2)
        {
            float distance = Vector3.Distance(StartObject.transform.position, EndObject.transform.position);
            transform.localScale = new Vector3(InitialScale.x, distance, InitialScale.z);

            Vector3 middlePoint = (StartObject.transform.position + EndObject.transform.position) / 2f;
            transform.position = middlePoint;

            Vector3 rotationDirection = (EndObject.transform.position - StartObject.transform.position);
            transform.up = rotationDirection;

            EndObject.transform.position = Vector3.MoveTowards(EndObject.transform.position, StartObject.transform.position, 0.2f);
        }
    }

    void ReverseDirection()
    {
        direction = 2;
    }
}
