using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SightUpDown : MonoBehaviour
{
    int rotSpeed = 10;
    void Update()
    {
        float MouseY = Input.GetAxis("Mouse Y");
        if (transform.rotation.y < -90)
            transform.Rotate(new Vector3(-90, 0, 0));
        else if(transform.rotation.y > 60)
            transform.Rotate(new Vector3(60, 0, 0));
        else
        transform.Rotate(new Vector3(-1,0,0) * rotSpeed * MouseY);

    }
}
