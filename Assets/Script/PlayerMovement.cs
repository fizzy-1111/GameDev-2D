using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    float rightMove;
    Vector3 upVector;
    Vector3 leftJump;
    Vector3 rightJump;
    Vector3 toRight;
    Rigidbody2D m_Rigidbody;
    Transform playerPos;
    public float speed = 0.1f;
    public bool grounded;
    void Start()
    {
        rightMove=  Time.fixedDeltaTime * speed;
        upVector = new Vector3(0,2, 0);
        leftJump = new Vector3(-1, 2, 0);
        rightJump = new Vector3(1, 2, 0);
        toRight = new Vector3(rightMove, 0, 0);
        m_Rigidbody = GetComponent<Rigidbody2D>();
        playerPos = transform;
        grounded = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space)&&grounded)
        {
            if (Input.GetKey(KeyCode.D)){
                m_Rigidbody.AddForce(rightJump * 100f);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                m_Rigidbody.AddForce(leftJump *100f);
            }
            else
            {
                m_Rigidbody.AddForce(upVector * 100f);
            }
            grounded = false;
        }
        if (Input.GetKey(KeyCode.D) && grounded)
        {
            playerPos.position += toRight;
        }
        if (Input.GetKey(KeyCode.A) && grounded)
        {
            playerPos.position -= toRight;

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground"||collision.gameObject.tag=="enemy")
        {
            grounded = true;
        }
    }
}
