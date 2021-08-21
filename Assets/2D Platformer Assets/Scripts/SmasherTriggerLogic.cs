using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SmasherTriggerLogic : MonoBehaviour
{
    private bool m_attackPlayer = false;

    public float attackSpeed = 5.0f;
    public float toIdleSpeed = 2.0f;
    private Vector3 startPosition;
    public GameObject colidedObject;

    private bool stayIdle = true;

    private bool resetPosition = false;

    private bool reachedIdlePosition = true;



    // Start is called before the first frame update
    void Start()
    {
        startPosition = colidedObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!stayIdle)
        {
            if (m_attackPlayer)
            {
                colidedObject.transform.Translate(Vector3.down * attackSpeed * Time.deltaTime);
            }    
        }

        if (resetPosition)
        {
            colidedObject.transform.position = Vector3.MoveTowards(colidedObject.transform.position, startPosition, toIdleSpeed * Time.deltaTime);
        }

        if (colidedObject.transform.position == startPosition)
        {
            resetPosition = false;
            reachedIdlePosition = true;
        }

        if (Vector3.Distance(colidedObject.transform.position, PlayerLogic.instance.transform.position) < .2f)
        {
            m_attackPlayer = false;
            resetPosition = true;
        }

        
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (reachedIdlePosition)
            {
                stayIdle = false;
                m_attackPlayer = true;
                reachedIdlePosition = false;
            }
            
            
        }

        if (other.tag == "SmasherKiller")
        {
            m_attackPlayer = false;
            resetPosition = true;
        }
    }
}
