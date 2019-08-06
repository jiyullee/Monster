using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseMaker : ItemManager
{
    float delay = 3.0f;
    GameObject player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnEnable()
    {
        GetComponent<AudioSource>().Play();
    }
    IEnumerator Wait(float delay)
    {
        yield return new WaitForSeconds(delay);
        GetComponent<AudioSource>().Play();
        
        Destroy(gameObject, 20.0f);
    }

    private void Update()
    {
        float diff = transform.position.x - player.transform.position.x;
        if (diff < 0)
            diff *= -1;

        GetComponent<AudioSource>().volume = 1 / diff;
    }

    private void OnDisable()
    {
        Monster.Instance.noiseItemList.Remove(gameObject);
    }

    public override void Function()
    {
       
    }
}
