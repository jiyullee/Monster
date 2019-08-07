using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Service;

public class ItemDestination : Singleton<ItemDestination>
{
    List<GameObject> noiseItemList = new List<GameObject>();
    [SerializeField] NavMeshAgent nvAgent;
    void Start()
    {           
        nvAgent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        float tr_x = transform.position.x;
        float tr_z = transform.position.z;
        for (int i = 0; i < noiseItemList.Count; i++)
        {
            float itemTr_x = noiseItemList[i].transform.position.x;
            float itemTr_z = noiseItemList[i].transform.position.z;
            float itemDistance = Mathf.Sqrt((itemTr_x - tr_x) * (itemTr_x - tr_x) + (itemTr_z - tr_z) * (itemTr_z - tr_z));
            if (itemDistance <= 100.0f)
            {
                nvAgent.destination = noiseItemList[i].transform.position;
                return;
            }
        }
    }
}
