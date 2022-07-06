using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public GameObject parent;
    public GameObject bulletPref;
    public float toX;
    public float toY;
    bool stickToParent = true;
    bool touchPlayer = false;
    public float speed = 0.1f;
    public float fireRate = 4f;
    private float lastShot = 0.0f;

    Animator anim;
    Rigidbody2D r2d;
    void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
        player = GameManager.Instance.truePlayer;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(parent.GetComponent<childControl>().yourturn);
        if (parent.GetComponent<childControl>().isDeath)
        {
            anim.SetTrigger("isDeath");
        }
        else
        {
            if(Vector3.Distance(player.transform.position, parent.transform.position) <= 5f)
                Dash();
            else Shoot();
            if (stickToParent)
            {
                transform.position = new Vector3(parent.transform.position.x + toX, parent.transform.position.y + toY, parent.transform.position.z);
            }
            if (parent.transform.position.x >= GameManager.Instance.playerMov.transform.position.x)
            {
                transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);


            }
            else
            {
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }

        }
    }
    void Dash()
    {
        if (myTurn())
        {

            if (Time.time > fireRate + lastShot)
            {
                anim.SetTrigger("isDashing");
                r2d.velocity = new Vector3(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y, 0).normalized * 6;
                lastShot = Time.time;
                stickToParent = false;
                Invoke("DoNothing", 0.8f);
            }
        }

    }
    void DoNothing()
    {
        Debug.Log("why not run");
        stickToParent = true;
    }
    bool myTurn()
    {
        if (gameObject.name == "Head1" && parent.GetComponent<childControl>().yourturn == 1) return true;
        if (gameObject.name == "Head2" && parent.GetComponent<childControl>().yourturn == 2) return true;
        if (gameObject.name == "Head3" && parent.GetComponent<childControl>().yourturn == 3) return true;
        return false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name =="Head1"|| collision.gameObject.name == "Head2" || collision.gameObject.name == "Head3")
        {
            Physics2D.IgnoreCollision(collision.collider, collision.otherCollider);
        }
        if (collision.gameObject.tag == "Player")
        {
            if(!stickToParent)
            GameManager.Instance.player.hitPoint -= 5;
        }
        if(collision.gameObject.tag == "bullet")
        {
            parent.GetComponent<childControl>().hitPoint -= 10;
        }
    }
    void Shoot()
    {
        if (Time.time > fireRate + lastShot)
        {
           
            Instantiate(bulletPref, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            lastShot = Time.time;
         
        }
    }

}
