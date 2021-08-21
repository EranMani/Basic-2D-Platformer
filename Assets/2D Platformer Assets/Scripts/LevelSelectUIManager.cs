using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectUIManager : MonoBehaviour
{
    public static LevelSelectUIManager instance;

    [SerializeField]
    private Image m_fadeScreen;

    [SerializeField]
    private float m_fadeSpeed;

    private bool m_shouldFadeToBlack, m_shouldFadeFromBlack;

    public GameObject levelInfoPanel;

    public Text levelName, gemsFound, gemsTarget, bestTime, timeTarget;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
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

    public void ShowInfo(MapPointLogic levelInfo)
    {
        levelName.text = levelInfo.levelName;

        gemsFound.text = "FOUND: " + levelInfo.gemsCollected;
        gemsTarget.text = "IN LEVEL: " + levelInfo.totalGems;

        timeTarget.text = "TARGET: " + levelInfo.targetTime + "s";

        if (levelInfo.bestTime == 0)
        {
            bestTime.text = "BEST: ---";
        }
        else
        {
            bestTime.text = "BEST: " + levelInfo.bestTime.ToString("F1") + "s";
        }

        levelInfoPanel.SetActive(true);
    }

    public void HideInfo() 
    {
        levelInfoPanel.SetActive(false);
    }
}
