using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Lancer : MonoBehaviour
{
    public GameObject player;
    int lancerPositionX, lancerPositionZ;
    int playerPositionX, playerPositionZ;
    float distance;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
        lancerPositionX = (int) transform.position.x;
        lancerPositionZ = (int)transform.position.z;
        playerPositionX = (int)player.transform.position.x;
        playerPositionZ = (int)player.transform.position.z;
        distance = Mathf.Sqrt( (lancerPositionX - playerPositionX) * (lancerPositionX - playerPositionX)  + (lancerPositionZ - playerPositionZ) * (lancerPositionZ - playerPositionZ));
        if (distance <= 3)
        {
            GetComponent<Animator>().SetBool("isRun", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("isRun", false);
        }

    }
}
