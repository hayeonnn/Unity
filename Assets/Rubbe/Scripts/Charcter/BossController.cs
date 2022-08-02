using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{

    [SerializeField] GameObject m_goPrefab = null;
    [SerializeField] Transform m_tfArrow = null;

    public GameObject MainChar;

    // Start is called before the first frame update
    void Start()
    {

    }

    void LookAtMainCharacter()
    {
        Vector2 t_MainCharacter = MainChar.transform.position;
        Vector2 t_direction = new Vector2(t_MainCharacter.x - m_tfArrow.position.x,
                                        t_MainCharacter.y - m_tfArrow.position.y);

        m_tfArrow.right = t_direction;
    }

    // Update is called once per frame
    void Update()
    {
        LookAtMainCharacter();
    }
}
