using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Scope_Maker : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rigid;

    public GameObject StartObject;
    public GameObject EndObject;
    public GameObject DestinationPoint;

    public Vector3 SP1;
    public Vector3 DP1;
    public float Timer1;

    public Vector3 SP2;
    public Vector3 DP2;
    public float Timer2;

    public Vector3 SP3;
    public Vector3 DP3;
    public float Timer3;

    GameObject MainChr;

    public Vector3 InitialScale;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();

        InitialScale = transform.localScale;
        MainChr = GameObject.Find("Character");
        StartObject.transform.position = MainChr.transform.position;

        Skill_Set1();

        if (Timer2 != 0)
        {
            Invoke("Skill_Set2", Timer2);
            if (Timer3 != 0)
            {
                Invoke("Skill_Set3", Timer3);
            }
        }
    }

    void Start()
    {
        InitialScale = transform.localScale;
        MainChr = GameObject.Find("Character");
        StartObject.transform.position = MainChr.transform.position;
        //DestinationPoint.transform.position = StartObject.transform.position + DP1;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(StartObject.transform.position, EndObject.transform.position);
        transform.localScale = new Vector3(InitialScale.x, distance, InitialScale.z);

        Vector3 middlePoint = (StartObject.transform.position + EndObject.transform.position) / 2f;
        transform.position = middlePoint;

        Vector3 rotationDirection = (EndObject.transform.position - StartObject.transform.position);
        transform.up = rotationDirection;

        EndObject.transform.position = Vector3.MoveTowards(EndObject.transform.position, DestinationPoint.transform.position, 0.3f);
    }

    void Skill_Set1()
    {
        StartObject.transform.position = MainChr.transform.position + SP1;
        DestinationPoint.transform.position = MainChr.transform.position + DP1;
        EndObject.transform.position = StartObject.transform.position;
    }
    void Skill_Set2()
    {
        StartObject.transform.position = MainChr.transform.position + SP2;
        DestinationPoint.transform.position = MainChr.transform.position + DP2;
        EndObject.transform.position = StartObject.transform.position;
    }
    void Skill_Set3()
    {
        StartObject.transform.position = MainChr.transform.position + SP3;
        DestinationPoint.transform.position = MainChr.transform.position + DP3;
        EndObject.transform.position = StartObject.transform.position;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("공격 성공");
        }
    }
}
