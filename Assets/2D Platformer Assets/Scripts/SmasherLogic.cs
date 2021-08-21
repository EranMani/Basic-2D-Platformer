using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmasherLogic : MonoBehaviour
{
    private bool m_attackPlayer = false;

    public float speed = 5.0f;

    public GameObject colidedObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (m_attackPlayer)
        {
            
        }   
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            m_attackPlayer = true;
        }
    }
}
