using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camFollow : MonoBehaviour
{
    // Start is called before the first frame update
    Transform player;
   
    public float speed = 2.0f;
    void Start()
    {
        player = GameManager.Instance.player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        float interpolation = speed * Time.deltaTime;
   
        Vector3 position = transform.position;
        position.y = Mathf.Lerp(transform.position.y, player.position.y+1, interpolation);
        position.x = Mathf.Lerp(transform.position.x, player.position.x+3, interpolation);

        transform.position = position;
       
    }
}
