using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkPoint : MonoBehaviour
{
    PlayerMovement plMove;

    void Start()
    {
        plMove = GameManager.Instance.playerMov;
        plMove.setPos(transform.position.x, transform.position.y,transform.position.z);
        if (GameManager.Instance.gameMode == "NewGame") gameObject.SetActive(true);
        else gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
