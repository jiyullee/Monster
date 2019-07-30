using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UseItem : MonoBehaviour
{
    public GameObject item;
    Sprite slotImage;
    private void Start()
    {
        slotImage = GetComponent<Image>().sprite;
    }
    public void Onclick()
    {
        if(item != null)
        {
            item.GetComponent<ItemManager>().Function();
            GetComponent<Image>().sprite = slotImage;
        }
              
    }
}
