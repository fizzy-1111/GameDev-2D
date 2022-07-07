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
    public bool isDying;
    void Awake()
    {
        maxhitPoint = 100;
        hitPoint = maxhitPoint;
        isDying = false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(hitPoint);
        if (hitPoint <= 0) { 
            hitPoint = 0;
            OnDeath();
        }
        attackSignal = false;
    }
    public void OnDeath()
    {
        GameManager.Instance.truePlayer.GetComponent<AnimatorController>().anim.SetBool("isDeath", true);
        isDying = true;
        Invoke("deathUI", 0.8f);

    }
    void deathUI()
    {
        GameManager.Instance.canvas.GetComponent<GameOverUI>().EndGame();
    }
}

