using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPointLogic : MonoBehaviour
{
    public MapPointLogic m_up, m_right, m_down, m_left;

    public bool m_isLevel;

    public bool isLocked;

    public string levelToLoad, levelUnlocked, levelName;

    public int gemsCollected, totalGems;
    public float bestTime, targetTime;

    public GameObject gemBadge, timeBadge;

    // Start is called before the first frame update
    void Start()
    {
        if (m_isLevel && levelToLoad != null)
        {
            if (PlayerPrefs.HasKey(levelToLoad + "_gems"))
            {
                gemsCollected = PlayerPrefs.GetInt(levelToLoad + "_gems");
            }

            if (PlayerPrefs.HasKey(levelToLoad + "_time"))
            {
                bestTime = PlayerPrefs.GetFloat(levelToLoad + "_time");
            }

            if (gemsCollected >= totalGems)
            {
                gemBadge.SetActive(true);
            }

            if (bestTime <= targetTime && bestTime != 0)
            {
                timeBadge.SetActive(true);
            }

            isLocked = true;

            if (levelUnlocked != null)
            {
                if (PlayerPrefs.HasKey(levelUnlocked + "_unlocked"))
                {
                    if (PlayerPrefs.GetInt(levelUnlocked + "_unlocked") == 1)
                    {
                        isLocked = false;
                    }
                    
                }
            }

            if (levelToLoad == levelUnlocked)
            {
                isLocked = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   
}
