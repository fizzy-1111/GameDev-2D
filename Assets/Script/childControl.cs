using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class childControl : MonoBehaviour
{
    // Start is called before the first frame update
    public int yourturn;
 
    bool block = false;
    public GameObject leftGun;
    public GameObject rightGun;
    public int hitPoint;
    public int maxhitPoint;
    public Slider slider;
    public Gradient gradient;
    public Image fill;

   public  bool isDeath = false;
    void Start()
    {
        yourturn = 1;
        maxhitPoint = 120;
        hitPoint = maxhitPoint;
        SetMaxHealth(maxhitPoint);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!block)
        {
            block = true;
            Invoke("childTurn", 2f);

        }
        SetHealth(hitPoint);
        if (hitPoint <= 0)
        {
            hitPoint = 0;
            isDeath = true;
            Invoke("OnDeath", 1f);
        }
    }
    void childTurn()
    {
        System.Random r = new System.Random();
        int n = r.Next(1, 4);
        yourturn = n;
        block = false;
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
    public void OnDeath()
    {
        Destroy(gameObject);
    }
}
