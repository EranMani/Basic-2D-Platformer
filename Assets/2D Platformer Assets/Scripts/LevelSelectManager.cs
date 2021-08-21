using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectManager : MonoBehaviour
{
    [SerializeField]
    private LevelSelectPlayerLogic m_thePlayer;

    private MapPointLogic[] m_allPoints;

    // Start is called before the first frame update
    void Start()
    {
        m_allPoints = FindObjectsOfType<MapPointLogic>();

        if (PlayerPrefs.HasKey("CurrentLevel"))
        {
            foreach (MapPointLogic point in m_allPoints)
            {
                if (point.levelToLoad == PlayerPrefs.GetString("CurrentLevel"))
                {
                    m_thePlayer.transform.position = point.transform.position;
                    m_thePlayer.SetNextPoint(point);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
 
    }

    public void LoadLevel()
    {
        StartCoroutine(LoadLevelCoroutine());
    }

    public IEnumerator LoadLevelCoroutine()
    {
        AudioManager.instance.PlaySFX(4);
        LevelSelectUIManager.instance.FadeToBlack();

        yield return new WaitForSeconds(1f / LevelSelectUIManager.instance.GetFadeSpeed() + .25f);

        SceneManager.LoadScene(m_thePlayer.GetCurrentPointInfo().levelToLoad);
    }
}
