using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    [SerializeField] GameObject player;
    float stamina;
    float maxstamina;
    // Start is called before the first frame update
    void Start()
    {
        maxstamina = player.GetComponent<PlayerHealth>().stamina;
    }

    // Update is called once per frame
    void Update()
    {
        stamina = player.GetComponent<PlayerHealth>().stamina;
        GetComponent<Image>().fillAmount = stamina / maxstamina;
    }
}
