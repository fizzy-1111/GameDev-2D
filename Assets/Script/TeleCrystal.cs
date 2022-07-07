using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleCrystal : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform destination;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.Instance.playerMov.setPos(destination.position.x, destination.position.y, 0);
        }
    }
}
