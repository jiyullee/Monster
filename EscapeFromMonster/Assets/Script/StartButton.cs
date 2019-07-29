using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public void GameStart(GameObject Loading)
    {
        SceneManager.LoadScene("SampleScene");
        Loading.SetActive(true);
    }
}
