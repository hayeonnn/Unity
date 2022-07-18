using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Custom_Preview : MonoBehaviour
{
    public GameObject Character;
    public Image target;
    
    public void Change_To_Preview()
    {
        Character.GetComponent<Image>().sprite = target.sprite;
    } 
}
