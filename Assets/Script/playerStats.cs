using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStats : MonoBehaviour
{
    // Start is called before the first frame update
    public int hitPoint;
    public int maxhitPoint;

    void Start()
    {
        maxhitPoint = 10;
        hitPoint = maxhitPoint;
    }

    // Update is called once per frame
    void Update()
    {
        if (hitPoint <= 0) { 
            hitPoint = 0;
            OnDeath();
        }

    }

    void OnDeath()
    {

    }
}
