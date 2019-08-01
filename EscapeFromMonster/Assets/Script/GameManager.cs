using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public float time;
    bool isGameOver = false;
    [SerializeField] GameObject GameOverUI;
    // Start is called before the first frame update
    void Start()
    {
      player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        
    }
    public void GameOver()
    {
        if (isGameOver == false)
        {
            GameOverUI.SetActive(true);
            Time.timeScale = 0;
        
        }
    }


    public void BacktotheMainmenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
        
    }
    public void ReGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("SampleScene");
    }
}
