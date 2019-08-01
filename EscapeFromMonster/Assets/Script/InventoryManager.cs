using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Service;

public class InventoryManager : Singleton<InventoryManager>
{
    public GameObject item;
    public GameObject[] inGameSlot;
    public List<int> slot1 = new List<int>();
    static int ptr = 0;
    bool isFull = false;
    private void Start()
    {
        for(int i = 0; i < inGameSlot.Length; i++)
        {
            slot1.Add(-1);
        }
    }
    public void InputItem(Sprite itemImage, int no)
    {
        //처음 슬롯에 삽입
        if (slot1 == null)
        {
            slot1[0] = no;
            inGameSlot[ptr].GetComponent<UseItem>().item = itemImage;
            inGameSlot[ptr].GetComponent<UseItem>().itemNo = slot1[ptr];
            inGameSlot[ptr].GetComponent<UseItem>().itemIndex = ptr;
            inGameSlot[ptr].GetComponent<Image>().sprite = itemImage;
            ptr++;
        }
        else
        {
            while (ptr < inGameSlot.Length && !isFull)
            {
                if (slot1[ptr] == -1)
                {
                    slot1[ptr] = no;
                    inGameSlot[ptr].GetComponent<UseItem>().item = itemImage;
                    inGameSlot[ptr].GetComponent<UseItem>().itemNo = slot1[ptr];
                    inGameSlot[ptr].GetComponent<UseItem>().itemIndex = ptr;
                    inGameSlot[ptr].GetComponent<Image>().sprite = itemImage;
                    ptr++;
                    break;
                }
            }
            if(ptr == inGameSlot.Length)
            {
                isFull = true;
                ptr = 0;
            }
        }                               
        
    }
 
}
