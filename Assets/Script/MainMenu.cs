using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public string desireScene;
    public bool toogle = false;
    
    void Start()
    {
        desireScene = "BossRoom";
        //UnityEditor.EditorApplication.isPlaying = true;
     
    }

    // Update is called once per frame

    public void NewGameButton()
    {
        SceneManager.LoadScene(desireScene);
        GameManager.Instance.gameMode = "NewGame";
    }
    public void CurrentGame()
    {
        string loadScene = GameManager.Instance.sceneToload;
        Debug.Log(loadScene);
        if (loadScene != "")
        {
            SceneManager.LoadScene(loadScene);
            GameManager.Instance.gameMode = "Old Game";
        }
    }
    public void ExitButton()
    {
        Application.Quit();
        Debug.Log("Game Closed");
    }
}
