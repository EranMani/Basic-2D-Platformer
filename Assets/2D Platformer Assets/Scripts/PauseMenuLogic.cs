using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuLogic : MonoBehaviour
{
    public static PauseMenuLogic instance;

    [SerializeField]
    private string m_levelSelect, m_mainMenu;

    [SerializeField]
    private GameObject m_pauseScreen;

    private bool m_isPaused;

    private void Awake()
    {
        instance = this;    
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseUnpause();
        }
    }

    public void PauseUnpause()
    {
        if (m_isPaused)
        {
            m_isPaused = false;
            m_pauseScreen.SetActive(false);
            Time.timeScale = 1f;
        }
        else
        {
            m_isPaused = true;
            m_pauseScreen.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void LevelSelect()
    {
        PlayerPrefs.SetString("CurrentLevel", SceneManager.GetActiveScene().name);

        SceneManager.LoadScene(m_levelSelect);
        Time.timeScale = 1f;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(m_mainMenu);
        Time.timeScale = 1f;
    }

    public bool CheckIfGamePaused()
    {
        return m_isPaused;
    }
}
