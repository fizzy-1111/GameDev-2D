using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    // Start is called before the first frame update
     public bool GamehasEnded = false;
     public GameObject UIGameOver;
    AudioSource audio;
    void Start()
    {
        UIGameOver.SetActive(false);
        audio = GetComponent<AudioSource>();
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
        audio.Play(0);
        Time.timeScale = 1f;
        Invoke("Play1", 0.5f);

    }
    public void NewGame()
    {
        audio.Play(0);
        Time.timeScale = 1f;
        Invoke("Play2", 0.5f);
    }
    public void Revive()
    {
        audio.Play(0);
        Time.timeScale = 1f;
        Invoke("Play3", 0.5f);
    }
    void Play1()
    {
        Destroy(GameManager.Instance.truePlayer);
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
        GameManager.Instance.gameMode = "NewGame";
    }
    void Play2()
    {
        Destroy(GameManager.Instance.truePlayer);
        SceneManager.LoadScene("Scene1");
        Time.timeScale = 1f;
        GameManager.Instance.gameMode = "NewGame";
    }
    void Play3()
    {
        string loadScene = GameManager.Instance.sceneToload;
        if (loadScene != "")
        {
            Destroy(GameManager.Instance.truePlayer);
            SceneManager.LoadScene(loadScene);
            Time.timeScale = 1f;
            GameManager.Instance.gameMode = "Old Game";
        }
    }
}
