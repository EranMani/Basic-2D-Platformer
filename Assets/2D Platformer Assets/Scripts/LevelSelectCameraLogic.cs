using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectCameraLogic : MonoBehaviour
{
    [SerializeField]
    private Vector2 m_minPos, m_maxPos;

    [SerializeField]
    private Transform m_target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float xPos = Mathf.Clamp(m_target.position.x, m_minPos.x, m_maxPos.x);
        float yPos = Mathf.Clamp(m_target.position.y, m_minPos.y, m_maxPos.y);

        transform.position = new Vector3(xPos, yPos, transform.position.z);
    }
}
