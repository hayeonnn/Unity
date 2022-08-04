using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{

    [SerializeField] GameObject m_goPrefab = null;
    [SerializeField] Transform m_tfArrow = null;

    public GameObject MainChar;
    public Vector2 t_MainCharacter;

    public int boss_Phase = 1;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("BossPattern", 0.5f, 4f);
    }

    void LookAtMainCharacter()
    {
        t_MainCharacter = MainChar.transform.position;
        Vector2 t_direction = new Vector2(t_MainCharacter.x - m_tfArrow.position.x,
                                        t_MainCharacter.y - m_tfArrow.position.y);

        m_tfArrow.right = t_direction;
    }

    void BossPattern()
    {
        if (boss_Phase == 1)
        {
            int temp = Random.Range(1, 4);
            if (temp == 1||temp==2)
            {
                Invoke("TryFire", 0.5f);
                Invoke("TryFire", 1f);
                Invoke("TryFire", 1.5f);
                Invoke("TryFire", 2f);
                Invoke("TryFire", 2.5f);
            }
            else if (temp == 3)
            {
                Invoke("JumpPhase1", 0.5f);
            }
        }
        else if (boss_Phase == 2)
        {
            Invoke("JumpPhase2", 0.5f);
        }
    }

    void TryFire()
    {
        float distance = Vector2.Distance(t_MainCharacter, transform.position);
        GameObject t_arrow = Instantiate(m_goPrefab, m_tfArrow.position, m_tfArrow.rotation);
        t_arrow.GetComponent<Rigidbody2D>().velocity = (t_arrow.transform.right * 9f * distance / 8) + (t_arrow.transform.up * -2f * distance / 5);
    }

    void JumpPhase1()
    {
        Invoke("JumpToSky", 0.1f);
        Invoke("JumpToPlayer", 1f);
        Invoke("ComeBack", 2.8f);
    }

    void JumpPhase2()
    {
        Invoke("JumpToSky", 0.1f);
        Invoke("JumpToPlayer", 1f);
        Invoke("JumpToPlayerAgain", 2.3f);
        Invoke("ComeBack", 3.8f);
    }

    void JumpToSky()
    {
        transform.GetComponentInParent<Rigidbody2D>().velocity = transform.parent.up * 30f;
    }

    void JumpToPlayer()
    {
        transform.GetComponentInParent<Rigidbody2D>().velocity = transform.parent.up * -10f;
        transform.parent.transform.position = MainChar.transform.position + (Vector3.up * 15f);
    }

    void JumpToPlayerAgain()
    {
        if (MainChar.transform.position.x - transform.parent.transform.position.x < 0)
            transform.GetComponentInParent<Rigidbody2D>().velocity = Vector2.up * 5f + Vector2.left * 5f;
        else
            transform.GetComponentInParent<Rigidbody2D>().velocity = Vector2.up * 5f + Vector2.right * 5f;
    }

    void ComeBack()
    {
        transform.GetComponentInParent<Rigidbody2D>().velocity = Vector2.zero;
        Vector3 temp=new Vector3(4.96000004f, -1.0032717f, 0);
        transform.parent.transform.position = temp;
    }

    // Update is called once per frame
    void Update()
    {
        LookAtMainCharacter();
    }
}
