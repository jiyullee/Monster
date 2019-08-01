using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Service;

public class InventoryManager : Singleton<InventoryManager>
{
    public GameObject item;
    public GameObject[] inGameSlot;
    public int slotNo;
    public List<int> slot1 = new List<int>();
    bool isFull = false;
    bool isEmpty = true;
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
        if (isEmpty)
        {
            slot1[0] = no;
            inGameSlot[0].GetComponent<UseItem>().item = itemImage;
            inGameSlot[0].GetComponent<UseItem>().itemNo = slot1[0];
            inGameSlot[0].GetComponent<Image>().sprite = itemImage;
            isEmpty = false;
        }
        else
        {
            int ptr = 0;
            while (ptr < inGameSlot.Length && !isFull)
            {
                if (slot1[ptr] == -1)
                {
                    slot1[ptr] = no;
                    inGameSlot[ptr].GetComponent<UseItem>().item = itemImage;
                    inGameSlot[ptr].GetComponent<UseItem>().itemNo = slot1[ptr];
                    inGameSlot[ptr].GetComponent<Image>().sprite = itemImage;                    
                    break;
                }
                ptr++;
            }
            
        }
       
        
    }

    private void Update()
    {
        int fullCount = 0;
        int emptyCount = 0;
        for (int i = 0; i < inGameSlot.Length; i++)
        {
            if (slot1[i] != -1)
                fullCount++;
            else
                emptyCount++;
        }
        if (fullCount == inGameSlot.Length)
            isFull = true;
        else if (emptyCount == inGameSlot.Length)
            isEmpty = true;
    }
}
