using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    [SerializeField]
    private float m_waitToRespawn;

    [SerializeField]
    private int m_gemsCollected;

    [SerializeField]
    private string m_levelToLoad;

    public float timeInLevel;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        timeInLevel = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timeInLevel += Time.deltaTime;
    }

    public void RespawnPlayer()
    {
        StartCoroutine(RespawnCoroutine());
    }

    private IEnumerator RespawnCoroutine()
    {
        PlayerLogic.instance.DeactivatePlayer();

        yield return new WaitForSeconds(m_waitToRespawn - (1f / UIManager.instance.GetFadeSpeed()));

        UIManager.instance.FadeToBlack();

        yield return new WaitForSeconds((1f / UIManager.instance.GetFadeSpeed()) + .2f);

        UIManager.instance.FadeFromBlack();

        PlayerLogic.instance.ActivatePlayer();
        PlayerLogic.instance.SetPlayerPosition(CheckPointManager.instance.GetSpawnPoint());

        PlayerHealthLogic.instance.RestorePlayerLives();

        UIManager.instance.UpdateHealthDisplay(PlayerHealthLogic.instance.GetCurrentPlayerLives());
    }

    public void CollectGem()
    {
        m_gemsCollected++;
        UIManager.instance.UpdateGemCount(m_gemsCollected);
    }

    public void EndLevel()
    {
        StartCoroutine(EndLevelCoroutine());
    }

    public IEnumerator EndLevelCoroutine()
    {
        AudioManager.instance.PlayLevelVictory();

        PlayerLogic.instance.StopPlayerInput();
        CameraLogic.instance.StopCameraFollowPlayer();
        UIManager.instance.SetLevelCompleteTextActive();

        yield return new WaitForSeconds(1.5f);

        UIManager.instance.FadeToBlack();

        
        yield return new WaitForSeconds(3f);
        PlayerLogic.instance.GetPlayerInput();
        CameraLogic.instance.CameraFollowPlayer();

        PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "_unlocked", 1);
        PlayerPrefs.SetString("CurrentLevel", SceneManager.GetActiveScene().name);

        if (PlayerPrefs.HasKey(SceneManager.GetActiveScene().name + "_gems"))
        {
            if (m_gemsCollected > PlayerPrefs.GetInt(SceneManager.GetActiveScene().name + "_gems"))
            {
                PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "_gems", m_gemsCollected);
            }
        }
        else
        {
            PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "_gems", m_gemsCollected);
        }

        if (PlayerPrefs.HasKey(SceneManager.GetActiveScene().name + "_time"))
        {
            if (timeInLevel < PlayerPrefs.GetFloat(SceneManager.GetActiveScene().name + "_time"))
            {
                PlayerPrefs.SetFloat(SceneManager.GetActiveScene().name + "_time", timeInLevel);
            }
        }
        else
        {
            PlayerPrefs.SetFloat(SceneManager.GetActiveScene().name + "_time", timeInLevel);
        }

        SceneManager.LoadScene(m_levelToLoad);

    }
}
