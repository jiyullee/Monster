using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destination : MonoBehaviour
{
    GameObject service;
    private void Start()
    {
        service = GameObject.FindGameObjectWithTag("Service");
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            service.GetComponent<GameManager>().GameComplete();
        }
    }
}
