using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour
{
    Rigidbody2D rd;
    CircleCollider2D col;
    public float distance;
    bool isFalling = false;

    private void Start()
    {
        rd = GetComponent<Rigidbody2D>();
        col = GetComponent<CircleCollider2D>();
    }

    private void Update()
    {
        Physics2D.queriesStartInColliders = false;
        if (isFalling==false)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, distance);

            Debug.DrawRay(transform.position, Vector2.down * distance, Color.red);

            if (hit.transform != null)
        {
            if (hit.transform.tag == "Player")
            {
                isFalling = true;
                rd.gravityScale = 5;
                // col.isTrigger = true;
            }
        }
        }
        
    }

    private void OnColliderEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
        }
        else
        {
            isFalling = false;
            rd.gravityScale = 0;
            col.isTrigger = false;
            // col.isTrigger = false;
        }
    }
}
