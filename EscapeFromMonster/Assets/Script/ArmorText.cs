using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArmorText : MonoBehaviour
{
    [SerializeField] GameObject service;
    GameObject player;
    // Start is called before the first frame update

    private void Start()
    {
        player = service.GetComponent<GameManager>().player;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = "Armor : " + player.GetComponent<PlayerHealth>().armor.ToString();
    }
}
