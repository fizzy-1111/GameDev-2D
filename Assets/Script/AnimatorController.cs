using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    public Animator anim;
    public bool isJumping = false;
    PlayerMovement t;
    playerStats e;
    public AudioSource audio1;
    public AudioSource audio2;
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
        if (!GameManager.Instance.player.isDying)
            Animate();
    }
    void Shoot()
    {
        audio2.Play();
        Instantiate(BulletPref, new Vector3(transform.position.x+0.6f*switchDir(),transform.position.y,transform.position.z), Quaternion.identity);
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
    void Animate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
      
            anim.SetBool("isJumping", true);
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            anim.SetTrigger("isSlashing");
            audio1.Play();
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
            GameManager.Instance.player.attackSignal = true;
           
           
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            anim.SetTrigger("isShooting");
            Shoot();
        }

    }
    int switchDir()
    {
        if (t.facingRight)
        {
            return 1;
        }
        else return -1;
    }


}
