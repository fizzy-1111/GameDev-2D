using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStats : MonoBehaviour
{
    // Start is called before the first frame update
    public int hitPoint;
    public int maxhitPoint;
    public bool attackSignal = false;
    public Vector3 nearEnemy=Vector3.zero;
    void Awake()
    {
        maxhitPoint = 10;
        hitPoint = maxhitPoint;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(hitPoint);
        if (hitPoint <= 0) { 
            hitPoint = 0;
            OnDeath();
        }

    }

    void OnDeath()
    {
        GameManager.Instance.canvas.GetComponent<GameOverUI>().EndGame();
    }
}

