using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreText1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        int score = PlayerPrefs.GetInt("Score");
        int minute = (int)score / 60;
        int sec = score % 60;
        GetComponent<Text>().text =  minute + " Min " + sec + " Sec";
    }


}
