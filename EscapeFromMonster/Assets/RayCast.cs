using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour
{
    public RaycastHit raycastHit;
    public LayerMask layerMask;
    public bool hit;
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);       
        hit = Physics.Raycast(ray, out raycastHit, 10, 1 << LayerMask.NameToLayer("Terrain"));       
    }
}

