using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UImanager : MonoBehaviour
{
    [SerializeField] GameObject inventory;
    bool isInventory = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            if (isInventory == false)
            {
                inventory.SetActive(true);
                isInventory = true;
            }
            else if(isInventory == true)
            {
                inventory.SetActive(false);
                isInventory = false;
            }

        }
    }

}
