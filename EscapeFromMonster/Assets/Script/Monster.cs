using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    [SerializeField] GameObject service;
    GameObject player;
    public int distance;
    [SerializeField] int detectDist;
    [SerializeField] int attackDist;
    [SerializeField] NavMeshAgent nvAgent;
    
    // Start is called before the first frame update
    void Start()
    {
        player = service.GetComponent<GameManager>().player;
        nvAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float tr_x = transform.position.x;
        float tr_z = transform.position.z;
        float target_x = player.transform.position.x;
        float target_z = player.transform.position.z;

        distance = (int)(Mathf.Sqrt((target_x - tr_x) * (target_x - tr_x) + (target_z - tr_z) * (target_z - tr_z)));

        if(distance <= detectDist && attackDist < distance)
        {
            GetComponent<Animator>().SetBool("Run", true);
            nvAgent.destination = player.transform.position;
        }
        else if(distance <= attackDist)
        {
            StartCoroutine(Attack());
        }
        else if(distance > detectDist)
        {
            GetComponent<Animator>().SetBool("Run", false);
            nvAgent.destination = transform.position;
        }
        
       
    }
    



    IEnumerator Attack()
    {
        GetComponent<Animator>().SetBool("Attack", true);
       
        yield return new WaitForSeconds(0.2f);
        GetComponent<Animator>().SetBool("Attack", false);

    }
}
