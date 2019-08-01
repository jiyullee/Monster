using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseMaker : MonoBehaviour
{
    float delay = 3.0f;
    GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnEnable()
    {
        StartCoroutine(Wait(delay));
    }
    IEnumerator Wait(float delay)
    {
        yield return new WaitForSeconds(delay);
        GetComponent<AudioSource>().Play();
        Destroy(gameObject, 5.0f);
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

}
