using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController_Tree : MonoBehaviour
{

    public GameObject MainChar;

    public int boss_Phase = 1;

    public ParticleSystem leaves;

    public GameObject Trunk;

    public GameObject Monster;
    public GameObject SpawnPos;

    public GameObject Boss_Eye_Color;

    public GameObject Buttom_Trunk;
    public GameObject warning;

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
            int temp = Random.Range(1, 3);
            Boss_Eye_Color.SetActive(true);
            if (temp == 1)
            {
                Invoke("Trunk_Attack", 1f);
            }
            else if (temp == 2)
            {
                Invoke("Summon_Monster", 1f);
            }
        }
        else if (boss_Phase == 2)
        {
            int temp = Random.Range(1, 3);
            if (temp == 1)
            {
                /*Invoke("Buttom_Trunk_Attack", 1f);
                Invoke("Buttom_Trunk_Attack", 1f);
                Invoke("Buttom_Trunk_Attack", 1f);
                Invoke("Buttom_Trunk_Attack", 1f);
                Invoke("Buttom_Trunk_Attack", 1f);
                Invoke("Buttom_Trunk_Attack", 1f);*/
                StartCoroutine(Phase2_Buttom_Trunk_Attack());
            }
            else if (temp == 2)
            {
                Invoke("Trunk_Attack", 1f);
                Invoke("Trunk_Attack", 2.3f);
            }
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

    void Trunk_Attack()
    {
        //Trunk.SetActive(true);
        GameObject temp = Instantiate(Trunk, Trunk.transform.position, Trunk.transform.rotation);
        Destroy(temp, 1.2f);
        Invoke("Boss_Eye_Color_Reset", 1.2f);
    }

    void Summon_Monster()
    {
        Instantiate(Monster, SpawnPos.transform);
        Invoke("Boss_Eye_Color_Reset", 1.2f);
    }

    void Boss_Eye_Color_Reset()
    {
        Boss_Eye_Color.SetActive(false);
    }

    void Buttom_Trunk_Attack(float startX)
    {
        /*float start_X = Random.Range(43.5f, 100.5f);
        Vector3 startPosition = Vector3.zero;
        startPosition.x = start_X;
        startPosition.y = Buttom_Trunk.transform.position.y;*/

        Vector3 startPosition = Vector3.zero;
        startPosition.x = startX;
        startPosition.y = Buttom_Trunk.transform.position.y;
        GameObject temp = Instantiate(Buttom_Trunk, startPosition, Buttom_Trunk.transform.rotation);
        Destroy(temp, 2f);
    }

    float Warning_Buttom_Trunk_Attack()
    {
        Vector3 startPosition = Vector3.zero;
        startPosition.x = MainChar.transform.position.x;
        startPosition.y = warning.transform.position.y;
        GameObject temp = Instantiate(warning, startPosition, warning.transform.rotation);
        Destroy(temp, 1.2f);

        return startPosition.x;
    }
    IEnumerator Phase2_Buttom_Trunk_Attack()
    {
        float PositionX = Warning_Buttom_Trunk_Attack();
        yield return new WaitForSeconds(1.2f);
        Buttom_Trunk_Attack(PositionX);
        float PositionX1 = Warning_Buttom_Trunk_Attack();
        yield return new WaitForSeconds(1.2f);
        Buttom_Trunk_Attack(PositionX1);
        float PositionX2 = Warning_Buttom_Trunk_Attack();
        yield return new WaitForSeconds(1.2f);
        Buttom_Trunk_Attack(PositionX2);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
