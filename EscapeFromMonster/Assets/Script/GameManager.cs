using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public float time;
    bool isGameOver = false;
    int destinationWait = 40;
    [SerializeField] GameObject GameOverUI;
    [SerializeField] GameObject GameCompleteUI;
    [SerializeField] GameObject Destination;
    [SerializeField] GameObject[] Destinations;
    // Start is called before the first frame update
    void Start()
    {
      player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(MakeDestination());
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
    public void GameComplete()
    {
        Time.timeScale = 0;
        GameCompleteUI.SetActive(true);

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
    IEnumerator MakeDestination()
    {
        yield return new WaitForSeconds(destinationWait);
        Destination.SetActive(true);
        Destinations[Random.Range(0, Destinations.Length)].SetActive(true);
    }
}
