using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthLogic : MonoBehaviour
{
    public static PlayerHealthLogic instance;

    [SerializeField]
    private int m_currentHealth, m_maxHealth;

    [SerializeField]
    private float m_noDamageLength;

    [SerializeField]
    private GameObject m_deathEffectPrefab;

    private float m_noDamageCounter;
    private SpriteRenderer m_spriteRenderer;

    

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        m_spriteRenderer = GetComponent<SpriteRenderer>();
        m_currentHealth = m_maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_noDamageCounter > 0)
        {
            m_noDamageCounter -= Time.deltaTime;
            if (CanGetDamage())
            {
                m_spriteRenderer.color = new Color(m_spriteRenderer.color.r, m_spriteRenderer.color.g, m_spriteRenderer.color.b, 1f);
            }
        }
    }

    public void DealDamage()
    {
        if (CanGetDamage())
        {
            RemovePlayerLife();
            UIManager.instance.UpdateHealthDisplay(m_currentHealth);
        }       
    }

    private bool CanGetDamage()
    {
        return m_noDamageCounter <= 0;
    }

    private void RemovePlayerLife()
    {
        m_currentHealth--;

        AudioManager.instance.PlaySFX(9);

        if (m_currentHealth <= 0)
        {
            m_currentHealth = 0;
            //gameObject.SetActive(false);
            Instantiate(m_deathEffectPrefab, transform.position, Quaternion.identity);

            AudioManager.instance.PlaySFX(8);

            LevelManager.instance.RespawnPlayer();
        }
        else
        {
            m_noDamageCounter = m_noDamageLength;
            m_spriteRenderer.color = new Color(m_spriteRenderer.color.r, m_spriteRenderer.color.g, m_spriteRenderer.color.b, 0.4f);
            PlayerLogic.instance.KnockBackPlayer();
        }

    }

    public void HealPlayer()
    {
        m_currentHealth++;
        if (m_currentHealth > m_maxHealth)
        {
            m_currentHealth = m_maxHealth;
        }

        UIManager.instance.UpdateHealthDisplay(m_currentHealth);
    }

    public void RestorePlayerLives()
    {
        m_currentHealth = m_maxHealth;
    }

    public int GetCurrentPlayerLives()
    {
        return m_currentHealth;
    }

    public int GetMaxLives()
    {
        return m_maxHealth;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Platform")
        {
            transform.parent = other.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Platform")
        {
            transform.parent = null;
        }
    }


}
