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
    public checkPoint check;
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
        Init();
    }

    public void saveState()
    {
        string s = " ";
        s += "0" + "|";
        s += player.hitPoint.ToString() + "|";
        PlayerPrefs.SetString("SaveState"+scene.name, s);
    }
    public void loadState(Scene s, LoadSceneMode load)
    {
       
        if (!PlayerPrefs.HasKey("SaveState"+scene.name)) return;
        string[] data = PlayerPrefs.GetString("SaveState" + scene.name).Split('|');
        Debug.Log(data[1]);
        if (player && playerMov != null)
        {
           // player.hitPoint = int.Parse(data[1]);
            //playerMov.transform.position = new Vector3(float.Parse(data[2]),float.Parse(data[3],0));

        }

    }
    void Init()
    {
        truePlayer = GameObject.FindGameObjectWithTag("Player");
        player = truePlayer.GetComponent<playerStats>();
        playerMov = truePlayer.GetComponent<PlayerMovement>();
        scene = SceneManager.GetActiveScene();
        DontDestroyOnLoad(player);
        Debug.Log("Init");
    }
    private void OnApplicationQuit()
    {
        
    }

}
