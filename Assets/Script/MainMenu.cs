using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //UnityEditor.EditorApplication.isPlaying = true;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("running");
    }

    public void NewGameButton()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void ExitButton()
    {
        //Application.Quit();
        Debug.Log("Game Closed");
    }
}
