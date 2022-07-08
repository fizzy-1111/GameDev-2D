using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossSkill : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 20f;
    public Rigidbody2D r2d;
    public GameObject boss;
    void Start()
    {
        r2d = gameObject.GetComponent<Rigidbody2D>();
        r2d.velocity = (GameManager.Instance.truePlayer.transform.position - transform.position).normalized*speed;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Vector3.Distance(transform.position,  > 10)
        //{
        //    Destroy(gameObject);
        //}
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Boss"||collision.gameObject.tag == "bossBullet")
        {
            Physics2D.IgnoreCollision(collision.collider, gameObject.GetComponent<CircleCollider2D>()) ;
        }
        else if(collision.gameObject.tag == "Player")
        {
            GameManager.Instance.player.hitPoint -= 2;
            Destroy(gameObject);

        }
        else Destroy(gameObject);
    }
}
