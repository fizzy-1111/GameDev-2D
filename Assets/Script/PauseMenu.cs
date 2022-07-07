using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool GameisPaused ;
    AudioSource audio;
    public GameObject UIPause;
    bool block = false;
    void Start()
    {
         UIPause.SetActive(false);
        GameisPaused = false;
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)&& !GameManager.Instance.canvas.GetComponent<GameOverUI>().GamehasEnded)
        {
            if (GameisPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    void Resume()
    {
        UIPause.SetActive(false);
        Time.timeScale = 1f;
        GameisPaused = false;
    }
    void Pause()
    {
        UIPause.SetActive(true);
        Time.timeScale = 0f;
        GameisPaused = true;
    }
    public void NewGame()
    {
        audio.Play(0);
        Time.timeScale = 1f;
        Invoke("Play1", 0.5f);

    }
    public void Return()
    {
        audio.Play(0);
        Resume();
        Invoke("Play2", 0.5f);

    }
    void doNothing()
    {
        
    }
    void Play1()
    {
        Destroy(GameManager.Instance.truePlayer);
        SceneManager.LoadScene("Scene1");
        GameManager.Instance.gameMode = "NewGame";
    }
    void Play2()
    {
       
        SceneManager.LoadScene("Menu");
        GameManager.Instance.gameMode = "";
        GameManager.Instance.saveState();
        Destroy(GameManager.Instance.truePlayer);
    }
    void Play3()
    {
       
    }
}
