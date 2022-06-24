using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    Collider2D m_ObjectCollider;

    public string desireScene;
    private void Start()
    {
        m_ObjectCollider = GetComponent<Collider2D>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag== "Player")
        {
            GameManager.Instance.saveState();
            SceneManager.LoadScene(desireScene);
        }
    }
}
