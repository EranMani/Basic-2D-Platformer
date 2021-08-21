using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchLogic : MonoBehaviour
{
    public GameObject objectToSwitch;
    public Sprite switchDownSprite;

    private SpriteRenderer m_spritreRenderer;
    private bool m_hasSwitched;

    public bool deactivateOnSwitch;

    // Start is called before the first frame update
    void Start()
    {
        m_spritreRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && !m_hasSwitched)
        {
            if (deactivateOnSwitch)
            {
                objectToSwitch.SetActive(false);
            }
            else
            {
                objectToSwitch.SetActive(true);
            }
            

            m_spritreRenderer.sprite = switchDownSprite;
            m_hasSwitched = true;
        }
    }
}
