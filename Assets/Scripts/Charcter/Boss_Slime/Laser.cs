using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private float defDistanceRay = 100;
    public Transform laserFirePoint;
    public LineRenderer m_lineRenderer;
    Transform m_transform;

    public GameObject mainCharacter;

    float mainCharacter_position_y;

    private void Awake()
    {
        m_transform = GetComponent<Transform>();
    }

    private void OnEnable()
    {
        mainCharacter_position_y = mainCharacter.transform.position.y;
    }

    void ShootLaser()
    {
        if (Physics2D.Raycast(m_transform.position, transform.right))
        {
            RaycastHit2D _hit = Physics2D.Raycast(laserFirePoint.position, transform.right * -1);
            //Draw2DRay(laserFirePoint.position, _hit.point);
            Draw2DRay(laserFirePoint.position, laserFirePoint.transform.right * defDistanceRay * -1);
        }
        else
        {
            Draw2DRay(laserFirePoint.position, laserFirePoint.transform.right*defDistanceRay);
        }
    }
    // Update is called once per frame
    void Update()
    {
        ShootLaser();
    }

    void Draw2DRay(Vector2 startPos,Vector2 endPos)
    {
        startPos.y = mainCharacter_position_y;
        endPos.y = startPos.y;
        m_lineRenderer.SetPosition(0, startPos);
        m_lineRenderer.SetPosition(1, endPos);
    }
}
