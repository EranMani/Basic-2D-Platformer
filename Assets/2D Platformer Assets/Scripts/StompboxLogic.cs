using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StompboxLogic : MonoBehaviour
{
    [SerializeField]
    private GameObject m_deathEffect;

    [SerializeField]
    private GameObject m_collectible;

    [SerializeField]
    [Range(0, 100)] private float m_chanceToDrop;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            other.transform.parent.gameObject.SetActive(false);
            Instantiate(m_deathEffect, other.transform.position, other.transform.rotation);
            PlayerLogic.instance.Bounce();

            float dropSelect = Random.Range(0f, 100f);
            if (dropSelect <= m_chanceToDrop)
            {
                Instantiate(m_collectible, other.transform.position, other.transform.rotation);
            }

            AudioManager.instance.PlaySFX(3);
        }
    }
}
