using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HighScoreText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      int score = PlayerPrefs.GetInt("Score");

        int minute =(int) score / 60;
        int sec = score % 60;

        GetComponent<Text>().text = "최고기록 : " + minute + "분 " + sec + "초";
      

    }
}
