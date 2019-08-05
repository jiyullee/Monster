using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    string[] loading = new string[] {"Loading", "Loading.","Loading..","Loading..." };
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadingText());
    }

    IEnumerator LoadingText()
    {
        
        for (int i = 0; i < loading.Length; i++)
        {
            GetComponent<Text>().text = loading[i];
            yield return new WaitForSeconds(0.5f);
            if (i == 3)
                i = -1;
        }
    }

}
