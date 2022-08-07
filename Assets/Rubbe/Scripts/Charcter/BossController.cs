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

    public GameObject Laser;

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
                Invoke("TryFire", 1.2f);
                Invoke("TryFire", 2.0f);
                Invoke("TryFire", 2.8f);
                Invoke("TryFire", 3.5f);
            }
            else if (temp == 3)
            {
                Invoke("JumpPhase1", 0.5f);
            }
        }
        else if (boss_Phase == 2)
        {
            int temp = Random.Range(1, 3);
            if (temp == 1)
            {
                Invoke("JumpPhase2", 0.5f);
            }
            else if (temp == 2)
            {
                Invoke("LaserOn", 0.5f);
            }
        }
    }

    void TryFire()
    {
        float distance = Vector2.Distance(t_MainCharacter, transform.position);
        GameObject t_arrow = Instantiate(m_goPrefab, m_tfArrow.position, m_tfArrow.rotation);
        //t_arrow.GetComponent<Rigidbody2D>().velocity = (t_arrow.transform.right * 9f * distance / 8) + (t_arrow.transform.up * -2f * distance / 5);
        t_arrow.GetComponent<Rigidbody2D>().velocity = calcBallisticVelocityVector(m_tfArrow.position, t_MainCharacter,30);
    }

    private Vector2 calcBallisticVelocityVector(Vector2 initialPos, Vector2 finalPos, float angle)
    {
        var toPos = initialPos - finalPos;

        var h = toPos.y;

        toPos.y = 0;
        var r = toPos.magnitude;

        var g = -Physics.gravity.y;

        var a = Mathf.Deg2Rad * angle;

        var vI = Mathf.Sqrt(((Mathf.Pow(r, 2f) * g)) / (r * Mathf.Sin(2f * a) + 2f * h * Mathf.Pow(Mathf.Cos(a), 2f)));

        Vector2 velocity = (finalPos- initialPos).normalized * Mathf.Cos(a);
        velocity.y = Mathf.Sin(a);

        return velocity * vI;
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
        Vector3 temp=new Vector3(99.6999969f, -23.0048084f, 0f);
        transform.parent.transform.position = temp;
    }

    void LaserOn()
    {
        Laser.SetActive(true);
        Invoke("LaserOff", 3f);
    }
    void LaserOff()
    {
        Laser.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        LookAtMainCharacter();
    }
}
