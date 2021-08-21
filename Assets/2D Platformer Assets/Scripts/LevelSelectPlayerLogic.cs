using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectPlayerLogic : MonoBehaviour
{
    [SerializeField]
    private MapPointLogic m_currentPoint;

    [SerializeField]
    private float m_moveSpeed = 10f;

    [SerializeField]
    private LevelSelectManager m_levelSelect;

    private bool m_levelLoading;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, m_currentPoint.transform.position, m_moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, m_currentPoint.transform.position) < .1f && !m_levelLoading)
        {
            if (Input.GetAxisRaw("Horizontal") > .5f)
            {
                if (m_currentPoint.m_right != null)
                {
                    SetNextPoint(m_currentPoint.m_right);
                }
            }

            if (Input.GetAxisRaw("Horizontal") < -.5f)
            {
                if (m_currentPoint.m_left != null)
                {
                    SetNextPoint(m_currentPoint.m_left);
                }
            }

            if (Input.GetAxisRaw("Vertical") > .5f)
            {
                if (m_currentPoint.m_up != null)
                {
                    SetNextPoint(m_currentPoint.m_up);
                }
            }

            if (Input.GetAxisRaw("Vertical") < -.5f)
            {
                if (m_currentPoint.m_down != null)
                {
                    SetNextPoint(m_currentPoint.m_down);
                }
            }

            if (m_currentPoint.m_isLevel && m_currentPoint.levelToLoad != "" && !m_currentPoint.isLocked)
            {
                LevelSelectUIManager.instance.ShowInfo(m_currentPoint);

                if (Input.GetButtonDown("Jump"))
                {
                    m_levelLoading = true;

                    m_levelSelect.LoadLevel();
                }
            }
        }
        
    }

    public void SetNextPoint(MapPointLogic nextPoint)
    {
        m_currentPoint = nextPoint;
        LevelSelectUIManager.instance.HideInfo();

        AudioManager.instance.PlaySFX(5);
    }

    public MapPointLogic GetCurrentPointInfo()
    {
        return m_currentPoint;
    }
}
