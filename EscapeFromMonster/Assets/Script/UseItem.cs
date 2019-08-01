using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UseItem : MonoBehaviour
{
    public Sprite item;
    Sprite slotImage;
    public int itemNo;
    public int itemIndex;
    public GameObject uiItemImage;
    private void Start()
    {
        slotImage = GetComponent<Image>().sprite;
    }
    public void Onclick()
    {
        uiItemImage.SetActive(true);
        uiItemImage.GetComponent<Image>().sprite =item;
        uiItemImage.GetComponent<SetItem>().itemNo = itemNo;

    }
   
     



}
