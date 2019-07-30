using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] int rotSpeed = 10;
    [SerializeField] int forwardSpeed = 5;
    [SerializeField] int runSpeed;
    int originForwardSpeed;
    [SerializeField] int sideSpeed = 4;
    [SerializeField] int backSpeed = 3;
    bool isBurnOut = false;
    bool isFlashOn = true;
    // Start is called before the first frame update
    void Start()
    {
        originForwardSpeed = forwardSpeed;
       
    }

    // Update is called once per frame
    void Update()
    {
        
        float stamina = GetComponent<PlayerHealth>().stamina;
        float MouseX = Input.GetAxis("Mouse X");
        
        transform.Rotate(Vector3.up * rotSpeed * MouseX);

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * sideSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.left * -sideSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * backSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftShift) && stamina > 0 && isBurnOut == false)
        {
            forwardSpeed = runSpeed;
            GetComponent<PlayerHealth>().isShift = true;
        }
        else if(isBurnOut == false)
        {
            GetComponent<PlayerHealth>().isShift = false;
            forwardSpeed = originForwardSpeed;
        }
        if (stamina == 0 && isBurnOut == false)
        {
            isBurnOut = true;
            StartCoroutine(Burnout());
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (isFlashOn == true)
            {
                isFlashOn = false;
                GetComponentInChildren<Light>().enabled = false;
            }
            else if (isFlashOn == false)
            {
                isFlashOn = true;
                GetComponentInChildren<Light>().enabled = true;
            }
        }
    }
    IEnumerator Burnout()
    {
        forwardSpeed = 1;
        yield return new WaitForSeconds(3);
        forwardSpeed = originForwardSpeed;
        isBurnOut = false;
    }
}
