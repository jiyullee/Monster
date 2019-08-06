using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class ItemManager : MonoBehaviour
{

    public Sprite itemImage;
    abstract public void Function();
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Function();
            Destroy(gameObject);
        }
    }
}
