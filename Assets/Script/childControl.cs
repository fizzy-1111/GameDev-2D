using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class childControl : MonoBehaviour
{
    // Start is called before the first frame update
    public int yourturn;
    Transform enemy;
    bool block = false;
    public GameObject leftGun;
    public GameObject rightGun;
    public int hitPoint;
    public int maxhitPoint;
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    bool toggle=true;

    public Transform spawnPoint;
    public Transform spawn2;
    float range1, range2;
    public  bool isDeath = false;
    public float speed = 10;
    public AudioSource audio1;
    public AudioSource audio2;
    void Start()
    {
        yourturn = 1;
        maxhitPoint = 120;
        hitPoint = maxhitPoint;
        SetMaxHealth(maxhitPoint);
        enemy = transform;
    }

    // Update is called once per frame
    void Update()
    {

        range1 = Vector3.Distance(spawnPoint.position, enemy.position);
        range2 = Vector3.Distance(spawn2.position, enemy.position);

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

        if (toggle)
        {
            enemy.position += (spawn2.position - spawnPoint.position) * Time.deltaTime * speed;

            if (range2 <= 1.5) toggle = false;
        }
        else
        {
            enemy.position += (spawnPoint.position - spawn2.position) * Time.deltaTime * speed;

            if (range1 <= 1.5) toggle = true;
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
        GameManager.Instance.canWin = true;
        Destroy(gameObject);
    }
}
