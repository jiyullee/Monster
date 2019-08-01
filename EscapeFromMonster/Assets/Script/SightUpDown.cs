using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SightUpDown : MonoBehaviour
{
    int rotSpeed = 10;
    void Update()
    {

        float MouseY = Input.GetAxis("Mouse Y");
        if (0.3f >= transform.localRotation.x && transform.localRotation.x >= -0.5f)
        {
            transform.Rotate(new Vector3(-1, 0, 0) * rotSpeed * MouseY);
        }
        else if (transform.localRotation.x < -0.5f && MouseY < 0)
            transform.Rotate(new Vector3(-1, 0, 0) * rotSpeed * MouseY);
        else if (transform.localRotation.x > 0.3f && MouseY > 0)
            transform.Rotate(new Vector3(-1, 0, 0) * rotSpeed * MouseY);


    }
}
