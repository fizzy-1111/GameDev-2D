using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;
    public playerStats player;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            //SceneManager.sceneLoaded += loadState;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);

        }
    }
}
