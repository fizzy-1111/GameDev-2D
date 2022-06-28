using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    // Start is called before the first frame update
     public bool GamehasEnded = false;
     public GameObject UIGameOver;

    void Start()
    {
        UIGameOver.SetActive(false);
    }

    public void EndGame()
    {
        if (!GamehasEnded)
        {
            GamehasEnded = true;
            Time.timeScale = 0f;
            UIGameOver.SetActive(true);
        }
    }
    public void MainMenu()
    {
        Destroy(GameManager.Instance.truePlayer);
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
        GameManager.Instance.gameMode = "NewGame";

    }
    public void NewGame()
    {
            
    }
}
