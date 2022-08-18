using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Open_Purchase_UI : MonoBehaviour
{
    public GameObject Purchase_Background;
    public Image Product_Image;

    public void Click_Purchase()
    {
        Purchase_Background.SetActive(true);
        Product_Image.sprite = transform.parent.Find("Background").Find("Image").GetComponent<Image>().sprite;
    }
}
