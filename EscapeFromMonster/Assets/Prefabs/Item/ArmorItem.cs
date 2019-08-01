using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorItem : ItemManager
{
    GameObject player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    public override void Function()
    {
        player.GetComponent<PlayerHealth>().IncreaseArmor();
        print(1);

    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Function();
            Destroy(gameObject);
        }
    }
}
