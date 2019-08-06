using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public GameObject noiseItem;
    public GameObject noiseMaker;
    public bool isEmpty = true;
    public bool isFull = false;
    public bool isPicked = false;
    public Sprite slotImage;
    public GameObject centerImage;
    private void Update()
    {
        if (isFull)
        {
            GetComponent<Image>().sprite = noiseItem.GetComponent<ItemManager>().itemImage;
        }
        else
        {
            GetComponent<Image>().sprite = slotImage;
        }
        if (Input.GetKey(KeyCode.R) && isFull && isPicked)
        {
            centerImage.gameObject.SetActive(false);
            RaycastHit raycastHit = Camera.main.GetComponent<RayCast>().raycastHit;
            Monster.Instance.noiseItemList.Add(Instantiate(noiseMaker, raycastHit.point, transform.rotation));
            isEmpty = true;
            isFull = false;
            isPicked = false;
        }
    }

    public void Onclick()
    {
        if (isFull)
        {
            centerImage.gameObject.SetActive(true);
            isPicked = true;
        }

    }

    
}
