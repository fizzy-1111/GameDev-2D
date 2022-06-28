using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;
    private Scene scene;
    public playerStats player;
    public PlayerMovement playerMov;
    public GameObject truePlayer;
    public GameObject canvas;
    public string sceneToload;
    public string gameMode;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            SceneManager.sceneLoaded += loadState;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);

        }
       

    }
    public void saveState()
    {
        string s = " ";
        s += "0" + "|";
        s += player.hitPoint.ToString() + "|";
        s += scene.name + "|";
        s += truePlayer.transform.position.x + "|";
        s += truePlayer.transform.position.y + "|";
        PlayerPrefs.SetString("SaveState" , s);
        //Debug.Log("is Saving");
    }
    public void loadState(Scene s, LoadSceneMode load)
    {
        canvas = GameObject.Find("Canvas");
       
        scene = SceneManager.GetActiveScene();
        if (!PlayerPrefs.HasKey("SaveState")||gameMode=="NewGame") return;

        string[] data = PlayerPrefs.GetString("SaveState").Split('|');
        sceneToload = data[2];

        if (player && playerMov != null && scene.name == sceneToload)
        {

            player.hitPoint = int.Parse(data[1]);

            playerMov.transform.position = new Vector3(float.Parse(data[3]), float.Parse(data[4]), 0);

        }


    }
    private void OnApplicationQuit()
    {
        if (scene.name!="Menu")
        {
            saveState();
        }
    }
    public Scene getScene()
    {
        return scene;
    }

}
