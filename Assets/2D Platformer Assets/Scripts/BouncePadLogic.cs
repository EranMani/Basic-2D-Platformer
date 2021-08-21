using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePadLogic : MonoBehaviour
{

    private Animator m_anim;

    public float bounceForce = 20f;

    // Start is called before the first frame update
    void Start()
    {
        m_anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
  
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PlayerLogic.instance.GetPlayerRigidbody().velocity = new Vector2(PlayerLogic.instance.GetPlayerRigidbody().velocity.x, bounceForce);
            m_anim.SetTrigger("Bounce");
        }
    }
}
