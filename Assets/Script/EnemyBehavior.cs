using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform spawnPoint;
    public Transform spawn2;
    Animator anim;
    Vector3 toRight;
    Vector3 toSpawn;

    bool toggle;
    float range1,range2,around;
    Transform enemy;
    public float speed = 0.1f;
    public float fireRate = 0.5f;
    private float lastShot = 0.0f;

    private playerStats Player;

    public int hitPoint;

    public Slider slider;
    
    public Image fill;

    void Start()
    {
        enemy = transform;
        toRight = new Vector3(Time.fixedDeltaTime*speed, 0, 0);
        toggle = true;                
        Player= GameManager.Instance.player;
        around = Vector3.Distance(spawnPoint.position, spawn2.position);
        hitPoint = 10;
        anim = GetComponent<Animator>();
       
        SetMaxHealth(10);
    }

    // Update is called once per frame
    void Update()
    {
        range1 = Vector3.Distance(spawnPoint.position, enemy.position);
        range2 = Vector3.Distance(spawn2.position, enemy.position);
        if (detectPlayer()&&(around>range2&&around>range1)&&between())
        {
            followPlayer();
        }
        else
        runningAround(range1,range2);
        SetHealth(hitPoint);
        if (hitPoint <= 0)
        {
            hitPoint = 0;
            onDeath();
        }
    }
    bool between()
    {
        if ((spawnPoint.position.x <= Player.transform.position.x && Player.transform.position.x <= spawn2.position.x) ||
           (spawn2.position.x <= Player.transform.position.x && Player.transform.position.x <= spawnPoint.position.x)
            )
        {
            return true;
        }
        else return false;
    }
    void runningAround(float range1,float range2)
    {
        if (toggle)
        {
            enemy.position += (spawn2.position - spawnPoint.position) * Time.deltaTime * speed;
            enemy.localScale = new Vector3(Mathf.Abs(enemy.localScale.x)*swapDir(), enemy.localScale.y, enemy.localScale.z);
          
            if (range2 <= 0.5) toggle = false;
        }
        else
        {
            enemy.position += (spawnPoint.position - spawn2.position) * Time.deltaTime * speed;
            enemy.localScale = new Vector3(Mathf.Abs(enemy.localScale.x) * swapDir(), enemy.localScale.y, enemy.localScale.z);
            
            if (range1 <= 0.5) toggle = true;
        }
    }
    void followPlayer()
    {
        if (Vector3.Distance(enemy.position, Player.transform.position) >1)
        {
            enemy.position += (Player.transform.position - enemy.position) * Time.deltaTime * speed*4;
            //Debug.Log(Vector3.Distance(enemy.position, Player.transform.position));
            GameManager.Instance.player.nearEnemy = Vector3.zero;
        }
        else
        {
            if (GameManager.Instance.player.attackSignal) hitPoint--;
            GameManager.Instance.player.nearEnemy = enemy.position;
            if (enemy.position.x >= GameManager.Instance.playerMov.transform.position.x)
            {
                enemy.localScale = new Vector3(-Mathf.Abs(enemy.localScale.x), enemy.localScale.y, enemy.localScale.z);
               
             
            }
            else
            {
                enemy.localScale = new Vector3(Mathf.Abs(enemy.localScale.x), enemy.localScale.y, enemy.localScale.z);
                
               
                
            }
            if (Time.time > fireRate + lastShot)
            {
                Player.hitPoint -= 1;
                lastShot = Time.time;
                anim.SetTrigger("nearPlayer");
            }
        }
    }
    bool detectPlayer()
    {
      
        if (Vector3.Distance(Player.transform.position, enemy.position) <= 5 && Mathf.Abs(Player.transform.position.y - enemy.transform.position.y) <= 2)
        {

            return true;
        }
        else return false;
    }

    void onDeath()
    {
        anim.SetTrigger("isDeath");

        Invoke("Kill", 1.5f);
    }
    void Kill()
    {
        Destroy(transform.parent.gameObject);
    }
    int swapDir()
    {
        if (toggle) return 1;
        else return -1;
    }

    public void SetMaxHealth(int health)
    {

        slider.maxValue = health;
        slider.value = health;

        //fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(int health)
    {
        slider.value = health;

        //fill.color = gradient.Evaluate(slider.normalizedValue);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            hitPoint--;
        }
    }
}
