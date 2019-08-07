using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseItem : ItemManager
{
    public override void Function()
    {
        InventoryManager.Instance.InputItem();
    }

}
