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
    [SerializeField] float attackDist;
    [SerializeField] NavMeshAgent nvAgent;
    public LayerMask playerLayerMask;
    int rand;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Roam());
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
            if (rand == 0)
                GetComponent<Animator>().SetBool("Walk", true);
            else if (rand == 1)
                GetComponent<Animator>().SetBool("Walk", false);
        }
        
       
    }
    



    IEnumerator Attack()
    {
        GetComponent<Animator>().SetBool("Attack", true);
        Ray ray = new Ray(transform.position, Vector3.forward);
        RaycastHit hit;
        if(Physics.Raycast(transform.position,Vector3.forward,out hit, attackDist) && hit.collider.gameObject.tag == "Player")
        {
            service.GetComponent<GameManager>().GameOver();
        }
        

        yield return new WaitForSeconds(0.2f);
        GetComponent<Animator>().SetBool("Attack", false);

    }
    IEnumerator Roam()
    {
        while (true)
        {
            int rand = Random.Range(0,1);
            yield return new WaitForSeconds(2);
        }
    }
}
