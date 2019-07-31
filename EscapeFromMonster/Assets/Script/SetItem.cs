using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetItem : MonoBehaviour
{
    public GameObject[] item;
    public int itemNo;
    private void Update()
    {
        print(itemNo);
        if (Input.GetKey(KeyCode.R))
        {
          
            gameObject.SetActive(false);
            bool hit = Camera.main.GetComponent<RayCast>().hit;
            if(hit)
            {
                RaycastHit raycastHit = Camera.main.GetComponent<RayCast>().raycastHit;
                GameObject temp = Instantiate(item[itemNo], raycastHit.point, transform.rotation);
                temp.GetComponent<ItemManager>().Function();
               // InventoryManager.Instance.slot1[]
            }
        }
    }
}

