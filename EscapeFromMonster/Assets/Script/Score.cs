using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] GameManager GameManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int score = (int)GameManager.time;
        int minute = (int) score / 60;
        int sec = score % 60;

        GetComponent<Text>().text = "Record : " + minute + "Min " + sec + "Sec";
    }
}
