using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{

    [SerializeField] GameObject m_goPrefab = null;
    [SerializeField] Transform m_tfArrow = null;

    public GameObject MainChar;
    public Vector2 t_MainCharacter;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("TryFire", 1f, 1f);
    }

    void LookAtMainCharacter()
    {
        t_MainCharacter = MainChar.transform.position;
        Vector2 t_direction = new Vector2(t_MainCharacter.x - m_tfArrow.position.x,
                                        t_MainCharacter.y - m_tfArrow.position.y);

        m_tfArrow.right = t_direction;
    }

    void TryFire()
    {
        float distance = Vector2.Distance(t_MainCharacter, transform.position);
        GameObject t_arrow = Instantiate(m_goPrefab, m_tfArrow.position, m_tfArrow.rotation);
        t_arrow.GetComponent<Rigidbody2D>().velocity = (t_arrow.transform.right * 8f * distance / 8) + (t_arrow.transform.up * -2f * distance / 5);
    }

    // Update is called once per frame
    void Update()
    {
        LookAtMainCharacter();
    }
}
