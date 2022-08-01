using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Custom_Preview : MonoBehaviour
{
    public GameObject Character;
    public Image target;

    public Sprite Original;
    
    public void Change_To_Preview()
    {
        if (Character.GetComponent<Image>().sprite == target.sprite)
        {
            Character.GetComponent<Image>().sprite = Original;
        }
        else
        {
            Character.GetComponent<Image>().sprite = target.sprite;
        }
    } 
}
