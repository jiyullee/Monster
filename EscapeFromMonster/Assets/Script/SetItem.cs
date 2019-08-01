using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetItem : MonoBehaviour
{
    public GameObject[] item;
    public int itemNo;
    public int slotNo;
    public Sprite slotImage;
    private void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {

            bool hit = Camera.main.GetComponent<RayCast>().hit;
            if(hit)
            {
                print(slotNo);
                RaycastHit raycastHit = Camera.main.GetComponent<RayCast>().raycastHit;
                GameObject temp = Instantiate(item[itemNo], raycastHit.point, transform.rotation);
                temp.GetComponent<ItemManager>().Function();
                InventoryManager.Instance.slot1[slotNo] = -1;
                InventoryManager.Instance.inGameSlot[slotNo].GetComponent<Image>().sprite = slotImage;

                Monster.Instance.noiseItemList.Add(temp);
                gameObject.SetActive(false);
            }
        }
    }
}

