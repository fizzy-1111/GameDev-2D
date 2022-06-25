using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public string desireScene;
    void Start()
    {
        desireScene = "Scene1";
        //UnityEditor.EditorApplication.isPlaying = true;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("running");
    }

    public void NewGameButton()
    {
        SceneManager.LoadScene(desireScene);
    }

    public void ExitButton()
    {
        //Application.Quit();
        Debug.Log("Game Closed");
    }
}
