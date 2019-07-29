using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float stamina = 100;
    public bool isShift = false;
    float increaseStamina = 1.0f;
    float decreaseStamina = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    private void Update()
    {
        if (isShift == false)
            StartCoroutine(IncreaseStamina());
        else if (isShift == true)
            StartCoroutine(DecreaseStamina());

    }
    IEnumerator IncreaseStamina()
    {
        stamina += increaseStamina;
        if (stamina >= 100)
            stamina = 100;
        yield return new WaitForSeconds(0.5f);

    }

    IEnumerator DecreaseStamina()
    {
        stamina -= decreaseStamina;

        if (stamina <= 0)
            stamina = 0;
        yield return new WaitForSeconds(0.5f);
    }
}
