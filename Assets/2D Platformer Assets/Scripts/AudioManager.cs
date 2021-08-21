using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField]
    private AudioSource[] m_soundEffects;

    [SerializeField]
    private AudioSource m_bgm, m_levelEnd, bossMusic;

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
        
    }

    public void PlaySFX(int soundToPlay)
    {
        m_soundEffects[soundToPlay].Stop();

        m_soundEffects[soundToPlay].pitch = Random.Range(.9f, 1.1f);

        m_soundEffects[soundToPlay].Play();
    }

    public void PlayLevelVictory()
    {
        m_bgm.Stop();
        m_levelEnd.Play();
    }

    public void PlayBossMusic()
    {
        m_bgm.Stop();
        bossMusic.Play();
    }

    public void StopBossMusic()
    {
        bossMusic.Stop();
        m_bgm.Play();
    }

}
