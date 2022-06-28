using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool GameisPaused ;

    public GameObject UIPause;
    void Start()
    {
         UIPause.SetActive(false);
        GameisPaused = false;   
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
        Debug.Log("Switch to new Game");
       
    }
    public void Return()
    {
        Resume();
        SceneManager.LoadScene("Menu");
        GameManager.Instance.gameMode = "";
        GameManager.Instance.saveState();
        Destroy(GameManager.Instance.truePlayer);

    }
}
