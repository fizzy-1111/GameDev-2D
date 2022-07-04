using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D r2d;
    // Start is called before the first frame update
    void Start()
    {
        r2d = gameObject.GetComponent<Rigidbody2D>();
        if(GameManager.Instance.playerMov.facingRight)
        r2d.velocity = transform.right * speed;
        else r2d.velocity = -transform.right * speed;
    }
    private void Update()
    {
        if (Vector3.Distance(transform.position, GameManager.Instance.truePlayer.transform.position) > 10)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

}
