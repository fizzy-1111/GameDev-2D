using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public string desireScene;
    public bool toogle = false;
    AudioSource audio;
    public AudioSource audio2;
    bool block = false;
    
    void Start()
    {
        //desireScene = "Scene1";
        //UnityEditor.EditorApplication.isPlaying = true;
        audio = GetComponent<AudioSource>();
        audio2.Play();
    }

    // Update is called once per frame

    public void NewGameButton()
    {
        audio.Play(0);
        Invoke("Play1", 0.5f);
       
    }
    public void CurrentGame()
    {
        audio.Play(0);
        Invoke("Play2", 0.5f);

    }
    public void ExitButton()
    {
        audio.Play(0);
        Invoke("Play3", 0.5f);

    }
    void Play1()
    {
        SceneManager.LoadScene(desireScene);
        GameManager.Instance.gameMode = "NewGame";
    }
    void Play2()
    {
        string loadScene = GameManager.Instance.sceneToload;
        Debug.Log(loadScene);
        if (loadScene != "")
        {
            SceneManager.LoadScene(loadScene);
            GameManager.Instance.gameMode = "Old Game";
        }
    }
    void Play3()
    {
        Application.Quit();
        Debug.Log("Game Closed");
    }
}
