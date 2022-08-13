using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController_Tree : MonoBehaviour
{

    public GameObject MainChar;

    public int boss_Phase = 1;

    public ParticleSystem leaves;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("BossPattern", 0.5f, 4f);
        InvokeRepeating("Falling_Leaves", 0.5f, 0.35f);
    }

    void BossPattern()
    {
        if (boss_Phase == 1)
        {

        }
    }

    void Falling_Leaves()
    {
        float start_X = Random.Range(43.5f, 100.5f);
        Vector3 startPosition = Vector3.zero;
        startPosition.x = start_X;
        startPosition.y = -6;
        Instantiate(leaves, startPosition, leaves.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
