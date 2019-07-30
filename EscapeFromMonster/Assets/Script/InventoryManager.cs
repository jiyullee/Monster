using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Service;

public class InventoryManager : Singleton<InventoryManager>
{
    public GameObject[] inGameSlot;
    GameObject[] slot = new GameObject[9];
    static int i = 0;
    bool isFull = false;
    public void InputItem(GameObject item)
    {
        while (i < inGameSlot.Length && isFull == false)
        {
            if (slot[i] == null)
            {
                slot[i] = item;
                inGameSlot[i].GetComponent<UseItem>().item = item;
                inGameSlot[i].GetComponent<Image>().sprite = item.GetComponent<ItemManager>().itemImage;
                break;
            }

            i++;
            
        }
        if (i == inGameSlot.Length)
        {
            isFull = true;
        }
            
    }  
    
}
