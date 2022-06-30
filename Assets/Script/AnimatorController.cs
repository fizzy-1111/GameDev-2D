using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    public Animator anim;
    public bool isJumping = false;
    PlayerMovement t;
    playerStats e;
    public GameObject BulletPref;
    void Start()
    {
        anim.SetBool("isJumping", false);
        t = GameManager.Instance.playerMov;
        e = GameManager.Instance.player;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            Debug.Log(isJumping);
            anim.SetBool("isJumping", true);
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            anim.SetTrigger("isSlashing");
            if (e.nearEnemy != Vector3.zero)
            {
                Debug.Log("near");
                if (e.nearEnemy.x >= t.transform.position.x)
                {
                    t.facingRight = true;
                    t.transform.localScale = new Vector3(Mathf.Abs(t.transform.localScale.x), t.transform.localScale.y, t.transform.localScale.z);
                }
                
                else
                {
                    t.facingRight = false;
                    t.transform.localScale = new Vector3(-Mathf.Abs(t.transform.localScale.x), t.transform.localScale.y, t.transform.localScale.z);
                }
            }
            else
            {
                
            }
           
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            anim.SetTrigger("isShooting");
            Shoot();
        }

    }
    void Shoot()
    {
        Instantiate(BulletPref, transform.position, transform.rotation);
    }
    private void FixedUpdate()
    {
        anim.SetFloat("Speed", Mathf.Abs(GameManager.Instance.playerMov.moveDirection * GameManager.Instance.playerMov.maxSpeed));
        if (GameManager.Instance.playerMov.isGrounded && isJumping)
        {
            isJumping = false;
            anim.SetBool("isJumping", false);
        }

    }


}
