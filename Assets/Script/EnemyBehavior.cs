using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform spawnPoint;
    public Transform spawn2;

    Vector3 toRight;
    Vector3 toSpawn;

    bool toggle;
    float range1,range2,around;
    Transform enemy;
    public float speed = 0.1f;
    public float fireRate = 0.5f;
    private float lastShot = 0.0f;

    private playerStats Player;
    public float fireRate = 0.5f;
    private float lastShot = 0.0f;

    public int hitPoint;
    void Start()
    {
        enemy = transform;
        toRight = new Vector3(Time.fixedDeltaTime*speed, 0, 0);
        toggle = true;
        Player= GameManager.Instance.player;
        around = Vector3.Distance(spawnPoint.position, spawn2.position);
        hitPoint = 10;
    }

    // Update is called once per frame
    void Update()
    {
       
        range1 = Vector3.Distance(spawnPoint.position, enemy.position);
        range2 = Vector3.Distance(spawn2.position, enemy.position);
        if (detectPlayer()&&(around>range2&&around>range1))
        {
            followPlayer();
        }
        else
        runningAround(range1,range2);
        if (hitPoint <= 0)
        {
            hitPoint = 0;
            onDeath();
        }
    }
    void runningAround(float range1,float range2)
    {
        if (toggle)
        {
            enemy.position += (spawn2.position - spawnPoint.position) * Time.deltaTime * speed;
            if (range2 <= 0.5) toggle = false;
        }
        else
        {
            enemy.position += (spawnPoint.position - spawn2.position) * Time.deltaTime * speed;
            if (range1 <= 0.5) toggle = true;
        }
    }
    void followPlayer()
    {
        if (Vector3.Distance(enemy.position, Player.transform.position) >=0.8)
        {
            enemy.position += (Player.transform.position - enemy.position) * Time.deltaTime * speed*4;

        }
        else
        {
            if (Time.time > fireRate + lastShot)
            {
                Player.hitPoint -= 1;
                lastShot = Time.time;
                hitPoint -= 2;
            }
        }
    }
    bool detectPlayer()
    {
      
        if (Vector3.Distance(Player.transform.position, enemy.position) <= 5&&Mathf.Abs(Player.transform.position.y-enemy.transform.position.y)<=0.5)
            return true;
        else return false;
    }

    void onDeath()
    {
        Destroy(gameObject);
    }
}
