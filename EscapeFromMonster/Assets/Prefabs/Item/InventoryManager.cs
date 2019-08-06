using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Service;

public class InventoryManager : Singleton<InventoryManager>
{
    public GameObject[] slot;
    public void InputItem()
    {
        int emptyCount = 0;
        int fullCount = 0;
        for(int i = 0; i < slot.Length; i++)
        {
            if (slot[i].GetComponent<Slot>().isEmpty)
                emptyCount++;
            if (slot[i].GetComponent<Slot>().isFull)
                fullCount++;
        }

        //모든 슬롯이 차있음
        if(fullCount == slot.Length)
        {
            return;
        }
        //모든 슬롯이 비어있음
        if(emptyCount == slot.Length)
        {
            slot[0].GetComponent<Slot>().isFull = true;
            slot[0].GetComponent<Slot>().isEmpty = false;
        }
        else
        {
            for(int i = 1; i < slot.Length; i++)
            {
                if (slot[i].GetComponent<Slot>().isEmpty)
                {
                    slot[i].GetComponent<Slot>().isFull = true;
                    slot[i].GetComponent<Slot>().isEmpty = false;
                    break;
                }

            }
        }


        
    }

}
