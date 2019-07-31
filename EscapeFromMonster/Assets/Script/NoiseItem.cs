using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseItem : ItemManager
{
    float delay = 3.0f;
    GameObject player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    public override void Function()
    {
        StartCoroutine(Wait(delay));
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            InventoryManager.Instance.InputItem(itemImage, itemNo);
            Destroy(gameObject);
        }
    }

    IEnumerator Wait(float delay)
    {
        yield return new WaitForSeconds(delay);
        GetComponent<AudioSource>().Play();
    }

    private void Update()
    {

        float diff = transform.position.x - player.transform.position.x;
        if (diff < 0)
            diff *= -1;

        GetComponent<AudioSource>().volume = 1 / diff;
    }

}
