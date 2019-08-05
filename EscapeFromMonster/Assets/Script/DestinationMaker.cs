using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationMaker : MonoBehaviour
{
    [SerializeField] GameObject[] Destination;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MakeDestination());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator MakeDestination()
    {
        yield return new WaitForSeconds(40);
        Destination[Random.Range(0, Destination.Length)].SetActive(true);
    }
}
