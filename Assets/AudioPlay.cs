using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlay : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip bgm1;
    public AudioSource audio1;
    void Start()
    {
        audio1.PlayOneShot(bgm1);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.canWin) audio1.Stop(); 
    }
}
