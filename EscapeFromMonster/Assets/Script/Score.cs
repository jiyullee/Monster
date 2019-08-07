using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] GameManager GameManager;
    int score;
    int minute;
    int sec;
    
    // Start is called before the first frame update
    void Start()
    {
        score = (int)GameManager.time;
        minute = (int)score / 60;
        sec = score % 60;
        if (PlayerPrefs.GetInt("Score")< score)
        {
            PlayerPrefs.SetInt("Score", score);
        }
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = "Record : " + minute + "Min " + sec + "Sec";
    }
}
