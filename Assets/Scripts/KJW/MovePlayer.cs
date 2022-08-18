using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MovePlayer : MonoBehaviour
{
    public GameObject player;
    public Button clickedBtn;
    public GameObject summary;
    private void Start()
    {
        summary.SetActive(false);
    }
    private void Update()
    {
        clickedBtn.onClick.AddListener(movePlayer);
    }

    public void movePlayer()
    {
        player.transform.localPosition = new Vector3(clickedBtn.transform.localPosition.x, clickedBtn.transform.localPosition.y + 100, clickedBtn.transform.localPosition.z);
        summary.SetActive(true);
    }

}
