using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupLogic : MonoBehaviour
{
    [SerializeField]
    private bool m_isGem, m_isHeal;

    [SerializeField]
    private GameObject m_pickupEffectPrefab;

    private bool m_isCollected;

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
        // in case the player has multiple colliders, make sure that the pick up will happen only once and not multiple times
        if (other.CompareTag("Player") && !m_isCollected)
        {
            if (m_isGem)
            {
                LevelManager.instance.CollectGem();
                m_isCollected = true;
                Destroy(this.gameObject);

                Instantiate(m_pickupEffectPrefab, transform.position, Quaternion.identity);

                AudioManager.instance.PlaySFX(6);
            }

            if (m_isHeal)
            {
                if (PlayerHealthLogic.instance.GetCurrentPlayerLives() != PlayerHealthLogic.instance.GetMaxLives())
                {
                    PlayerHealthLogic.instance.HealPlayer();
                    m_isCollected = true;
                    Destroy(this.gameObject);

                    Instantiate(m_pickupEffectPrefab, transform.position, Quaternion.identity);
                }

                AudioManager.instance.PlaySFX(7);
            }


        }
    }
}
