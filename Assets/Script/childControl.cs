using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class childControl : MonoBehaviour
{
    // Start is called before the first frame update
    public int yourturn;
    bool block = false;
    void Start()
    {
        yourturn = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (!block)
        {
            block = true;
            Invoke("childTurn", 2f);

        }
    }
    void childTurn()
    {
        System.Random r = new System.Random();
        int n = r.Next(1, 4);
        yourturn = n;
        block = false;
    }
}
