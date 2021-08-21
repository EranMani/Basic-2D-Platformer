using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointLogic : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer m_SpriteRenderer;

    [SerializeField]
    private Sprite m_checkPointOn, m_checkPointOff;

    

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
        if (other.CompareTag("Player"))
        {
            CheckPointManager.instance.DeactivateCheckPoints();
            m_SpriteRenderer.sprite = m_checkPointOn;
            AudioManager.instance.PlaySFX(5);
            CheckPointManager.instance.SetSpawnPoint(transform.position);
        }
    }

    public void ResetCheckPoint()
    {
        m_SpriteRenderer.sprite = m_checkPointOff;
    }

    
}
