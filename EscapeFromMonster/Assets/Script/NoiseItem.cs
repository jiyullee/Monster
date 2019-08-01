using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseItem : ItemManager
{
    public override void Function()
    {
        
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            InventoryManager.Instance.InputItem(itemImage, itemNo);
            Destroy(gameObject);
        }
    }

}
