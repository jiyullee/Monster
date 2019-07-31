using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    private float time;
    // Start is called before the first frame update
    void Start()
    {
     player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
    //    Debug.Log(" timer   :" + time + "seconds");
    }
    public void GameOver()
    {

    }
}
