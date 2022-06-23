using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camFollow : MonoBehaviour
{
    // Start is called before the first frame update
    Transform player;
    int direction;
    public float speed = 2.0f;
    void Start()
    {
        player = GameManager.Instance.player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        float interpolation = speed * Time.deltaTime;
        direction = GameManager.Instance.playerMov.direction;
        Vector3 position = transform.position;
        position.y = Mathf.Lerp(transform.position.y, player.position.y+2, interpolation);
        position.x = Mathf.Lerp(transform.position.x, player.position.x+5, interpolation);

        transform.position = position;
        Debug.Log(direction);
    }
}
