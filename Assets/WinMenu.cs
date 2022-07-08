using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinMenu : MonoBehaviour
{
    // Start is called before the first frame update
    AudioSource audio;
    public AudioSource audio2;
    public AudioSource another;
    public bool GamehasEnded = false;
    public GameObject GameObjectUIWin;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MainMenu()
    {
        audio.Play(0);
        Time.timeScale = 1f;
      

    }
    public void NewGame()
    {
        audio.Play(0);
        Time.timeScale = 1f;
       
    }
    public void EndGame()
    {
        if (!GamehasEnded)
        {
            GamehasEnded = true;
            Time.timeScale = 0f;
            audio2.Play();
            GameObjectUIWin.SetActive(true);
        }
    }
}
