using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : MonoBehaviour
{
    public AudioClip[] bgm;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(BGMPlayer());   
    }

    IEnumerator BGMPlayer()
    {
        int waitTime = Random.Range(20, 60);
        GetComponent<AudioSource>().clip = bgm[Random.Range(0, bgm.Length)];
        GetComponent<AudioSource>().Play(3);
        yield return new WaitForSeconds(waitTime);
    }

}
