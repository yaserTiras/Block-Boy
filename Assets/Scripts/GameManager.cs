using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool GameStarted = false;
    void Start()
    {
        Invoke("StartGame", 2);
    }

    public void StartGame()
    {
        GameStarted = true;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
