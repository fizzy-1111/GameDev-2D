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
    float range1,range2;
    Transform enemy;
    public float speed = 0.1f;

    [SerializeField]GameObject Player;
    void Start()
    {
        enemy = transform;
        toRight = new Vector3(Time.fixedDeltaTime*speed, 0, 0);
        toggle = true;
    }

    // Update is called once per frame
    void Update()
    {

        //Debug.Log(Vector3.Distance(Player.transform.position, enemy.position));
        if (detectPlayer())
        {
            followPlayer();
        }
        else
        runningAround();
    }
    void runningAround()
    {
        range1 = Vector3.Distance(spawnPoint.position, enemy.position);
        range2 = Vector3.Distance(spawn2.position, enemy.position);
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
        Debug.Log(range2);
    }
    void followPlayer()
    {
        enemy.position += (Player.transform.position - enemy.position) * Time.deltaTime * speed*4;
    }
    bool detectPlayer()
    {
      
        if (Vector3.Distance(Player.transform.position, enemy.position) <= 5&&Mathf.Abs(Player.transform.position.y-enemy.transform.position.y)<=2)
            return true;
        else return false;
    }
}
