using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class specialScale : MonoBehaviour
{
    Transform t;
    public EnemyBehavior follow;
    void Start()
    {
        t = transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(follow.transform.position.x, follow.transform.position.y+0.5f, follow.transform.position.z);
    }
}
