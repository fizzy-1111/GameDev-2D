using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    PlayerMovement plMove;
    void Awake()
    {
        if (GameManager.Instance.truePlayer == null)
        {
            Debug.Log("Null");
            GameManager.Instance.truePlayer = Instantiate(player, transform.position, Quaternion.identity);
            GameManager.Instance.player = GameManager.Instance.truePlayer.GetComponent<playerStats>();
            GameManager.Instance.playerMov = GameManager.Instance.truePlayer.GetComponent<PlayerMovement>();
            DontDestroyOnLoad(GameManager.Instance.player);
        }
        else
        {
            Debug.Log("Working");
            plMove = GameManager.Instance.playerMov;
            plMove.setPos(transform.position.x, transform.position.y, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
