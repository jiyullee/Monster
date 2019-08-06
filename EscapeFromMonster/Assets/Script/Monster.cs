using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Service;
public class Monster : Singleton<Monster>
{
    GameObject service;
    GameObject player;
    public List<GameObject> noiseItemList = new List<GameObject>();
    public int distance;
    [SerializeField] int detectDist;
    [SerializeField] float attackDist;
    [SerializeField] NavMeshAgent nvAgent;
    public LayerMask playerLayerMask;
    public float attackDelay;
    int rand;
    bool attack = false;
    bool petrol = false;
    Vector3 petrolPos;
    
    // Start is called before the first frame update
    void Start()
    {
        service = GameObject.FindGameObjectWithTag("Service");
        StartCoroutine(Roam());
        player = service.GetComponent<GameManager>().player;
        nvAgent = GetComponent<NavMeshAgent>();
        StartCoroutine(DestinationMaker());
    }

    // Update is called once per frame
    void Update()
    {
        float tr_x = transform.position.x;
        float tr_z = transform.position.z;
        float target_x = player.transform.position.x;
        float target_z = player.transform.position.z;

        distance = (int)(Mathf.Sqrt((target_x - tr_x) * (target_x - tr_x) + (target_z - tr_z) * (target_z - tr_z)));
        for(int i = 0; i < noiseItemList.Count; i++)
        {
            float itemTr_x = noiseItemList[i].transform.position.x;
            float itemTr_z = noiseItemList[i].transform.position.z;
            float itemDistance = Mathf.Sqrt((itemTr_x - tr_x) * (itemTr_x - tr_x) + (itemTr_z - tr_z) * (itemTr_z - tr_z));
            if(itemDistance <= 100.0f)
            {
                nvAgent.destination = noiseItemList[i].transform.position;
                return;
            }
        }
        if (distance <= detectDist && attackDist < distance)
        {
            GetComponent<Animator>().SetBool("Run", true);
            GetComponent<Animator>().SetBool("Attack", false);
            nvAgent.destination = player.transform.position;
        }
        else if(distance <= attackDist)
        {
            Vector3 dir = player.transform.position - transform.position;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), 10);
            GetComponent<Animator>().SetBool("Attack", true);
            if(attack == false)
            StartCoroutine(Attack());
        }
        else if(distance > detectDist)
        {
            GetComponent<Animator>().SetBool("Run", false);
            
            if (rand == 0)
            {
                GetComponent<Animator>().SetBool("Walk", true);
                nvAgent.destination = petrolPos;
            }
            else if (rand == 1)
            {
                GetComponent<Animator>().SetBool("Walk", false);
                nvAgent.destination = transform.position;
            }
        }
    
    }
    



    IEnumerator Attack()
    {
        attack = true;
        Ray ray = new Ray(transform.position + new Vector3(0, 1, 0), player.transform.position-transform.position);
        RaycastHit hit;
        Debug.DrawRay(ray.origin, ray.direction * attackDist, Color.red, 5f);

        if (Physics.Raycast(transform.position, player.transform.position - transform.position, out hit, attackDist) && hit.collider.gameObject.tag == "Player")
        {
           
            print("Hit");
            if (player.GetComponent<PlayerHealth>().armor > 0)
            {
                player.GetComponent<PlayerHealth>().armor -= 1;
            }
            else if (player.GetComponent<PlayerHealth>().armor <= 0)
            {
                service.GetComponent<GameManager>().GameOver();
            }
            
        }

        nvAgent.speed = 0;
        yield return new WaitForSeconds(attackDelay);
        nvAgent.speed = 3.5f;
        attack = false;
    }
    IEnumerator Roam()
    {
        while (true)
        {
            int rand = Random.Range(0,1);
            yield return new WaitForSeconds(2);
        }
    }

    IEnumerator DestinationMaker()
    {
        while (true)
        {
            yield return new WaitForSeconds(3);
            petrolPos = transform.position + new Vector3(Random.Range(-70,70),0, Random.Range(-70, 70));

        }
    }
}
