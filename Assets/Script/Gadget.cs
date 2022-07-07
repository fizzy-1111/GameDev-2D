using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gadget : MonoBehaviour
{
    // Start is called before the first frame update
    public string gadgetName;
    public Transform spawnPoint;
    public Transform spawn2;
    bool toggle = true;
    float speed = 0.2f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        setUp();
    }
    void setUp()
    {
        switch (gadgetName)
        {
            case "Moving Rock":
                float range1 = Vector3.Distance(spawnPoint.position, transform.position);
                float range2 = Vector3.Distance(spawn2.position, transform.position);
                if (toggle)
                {
                    transform.position += (spawn2.position - spawnPoint.position) * Time.deltaTime * speed;

                    if (range2 <= 0.5) toggle = false;
                }
                else
                {
                    transform.position += (spawnPoint.position - spawn2.position) * Time.deltaTime * speed;

                    if (range1 <= 0.5) toggle = true;
                }
                break;
            case "Rotating Plane":
                transform.Rotate(Vector3.forward * (speed*50 * Time.deltaTime));
                break;
            default:
                break;
        }
    }

}
