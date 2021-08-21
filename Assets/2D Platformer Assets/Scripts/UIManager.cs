using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField]
    private Image m_heart1, m_heart2, m_heart3;

    [SerializeField]
    private Sprite m_heartFull, m_halfHeart, m_heartEmpty;

    [SerializeField]
    private Text m_getAmountText;

    [SerializeField]
    private Image m_fadeScreen;

    [SerializeField]
    private float m_fadeSpeed;

    private bool m_shouldFadeToBlack, m_shouldFadeFromBlack;

    [SerializeField]
    private GameObject m_levelCompleteText;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        m_getAmountText.text = "" + 0;
        FadeFromBlack();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_shouldFadeToBlack)
        {
            m_fadeScreen.color = new Color(m_fadeScreen.color.r, m_fadeScreen.color.g,
                                           m_fadeScreen.color.b, 
                                           Mathf.MoveTowards(m_fadeScreen.color.a, 1f, m_fadeSpeed * Time.deltaTime));
            if (m_fadeScreen.color.a == 1)
            {
                m_shouldFadeToBlack = false;
            }
        }

        if (m_shouldFadeFromBlack)
        {
            m_fadeScreen.color = new Color(m_fadeScreen.color.r, m_fadeScreen.color.g,
                                           m_fadeScreen.color.b,
                                           Mathf.MoveTowards(m_fadeScreen.color.a, 0f, m_fadeSpeed * Time.deltaTime));
            if (m_fadeScreen.color.a == 0)
            {
                m_shouldFadeFromBlack = false;
            }
        }
    }

    public void UpdateHealthDisplay(int playerHealth)
    {
        switch (playerHealth)
        {
            case 6:
                m_heart1.sprite = m_heartFull;
                m_heart2.sprite = m_heartFull;
                m_heart3.sprite = m_heartFull;
                break;
            case 5:
                m_heart1.sprite = m_heartFull;
                m_heart2.sprite = m_heartFull;
                m_heart3.sprite = m_halfHeart;
                break;
            case 4:
                m_heart1.sprite = m_heartFull;
                m_heart2.sprite = m_heartFull;
                m_heart3.sprite = m_heartEmpty;
                break;
            case 3:
                m_heart1.sprite = m_heartFull;
                m_heart2.sprite = m_halfHeart;
                m_heart3.sprite = m_heartEmpty;
                break;
            case 2:
                m_heart1.sprite = m_heartFull;
                m_heart2.sprite = m_heartEmpty;
                m_heart3.sprite = m_heartEmpty;
                break;
            case 1:
                m_heart1.sprite = m_halfHeart;
                m_heart2.sprite = m_heartEmpty;
                m_heart3.sprite = m_heartEmpty;
                break;
            case 0:
                m_heart1.sprite = m_heartEmpty;
                m_heart2.sprite = m_heartEmpty;
                m_heart3.sprite = m_heartEmpty;
                break;
        }
    }

    public void UpdateGemCount(int gemAmount)
    {
        m_getAmountText.text = "" + gemAmount;
    }

    public void FadeToBlack()
    {
        m_shouldFadeToBlack = true;
        m_shouldFadeFromBlack = false;
    }

    public void FadeFromBlack()
    {
        m_shouldFadeFromBlack = true;
        m_shouldFadeToBlack = false;     
    }

    public float GetFadeSpeed()
    {
        return m_fadeSpeed;
    }

    public void SetLevelCompleteTextActive()
    {
        m_levelCompleteText.SetActive(true);
    }
}
