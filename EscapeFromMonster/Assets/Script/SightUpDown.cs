using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SightUpDown : MonoBehaviour
{
    int rotSpeed = 10;
    void Update()
    {
        float MouseY = Input.GetAxis("Mouse Y");

        if (-90 < transform.rotation.x && transform.rotation.x < 60)
        {
            transform.Rotate(new Vector3(-1, 0, 0) * rotSpeed * MouseY);
        }
        else if (transform.rotation.y < -90)
            transform.Rotate(new Vector3(-89, 0, 0));
        else if (transform.rotation.y > 60)
            transform.Rotate(new Vector3(59, 0, 0));

    }
}
