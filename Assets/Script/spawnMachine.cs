using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnMachine : MonoBehaviour
{
    // Start is called before the first frame update
    public EnemyBehavior enemy;
    public Transform spawn2;
    EnemyBehavior enemyClone;
    void Start()
    {

        if (enemy != null&&spawn2!=null)
        {
            enemy.spawnPoint = transform;
            enemy.spawn2 = spawn2;
            enemyClone=Instantiate(enemy, transform.position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyClone == null)
        {
            Invoke("createNewEnemy", 2.0f);
        }
    }
    void createNewEnemy()
    {
        if(enemyClone==null)
        enemyClone = Instantiate(enemy, transform.position, Quaternion.identity);
    }
}
