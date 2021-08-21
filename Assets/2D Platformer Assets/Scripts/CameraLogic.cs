using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLogic : MonoBehaviour
{
    public static CameraLogic instance;

    [SerializeField]
    private Transform m_targetFollowPosition;

    [SerializeField]
    private Transform m_farBackground, m_middleBackground;

    [SerializeField]
    private float m_minHeight, m_maxHeight;

    [SerializeField]
    private float m_parallaxMoveThreshold;

    // private float m_lastXPos;
    private Vector2 m_cameraParallaxLastPos;

    private bool m_stopFollow;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        // m_lastXPos = transform.position.x;
        m_cameraParallaxLastPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!m_stopFollow)
        {
            CameraMovement();
        }

    }

    private void CameraMovement()
    {
        /*
        transform.position = new Vector3(m_targetFollowPosition.position.x, m_targetFollowPosition.position.y, transform.position.z);
        float clampedY = Mathf.Clamp(transform.position.y, m_minHeight, m_maxHeight);
        transform.position = new Vector3(transform.position.x, clampedY, transform.position.z);
        */

        transform.position = new Vector3(m_targetFollowPosition.position.x,
                                        Mathf.Clamp(m_targetFollowPosition.position.y, m_minHeight, m_maxHeight),
                                        transform.position.z);

        Vector2 amountToMove = new Vector2(transform.position.x - m_cameraParallaxLastPos.x,
                                           transform.position.y - m_cameraParallaxLastPos.y);

        m_farBackground.position = m_farBackground.position + new Vector3(amountToMove.x, amountToMove.y, 0f);
        m_middleBackground.position += new Vector3(amountToMove.x, amountToMove.y, 0f) * m_parallaxMoveThreshold;

        m_cameraParallaxLastPos = transform.position;
    }

    public void StopCameraFollowPlayer()
    {
        m_stopFollow = true;
    }

    public void CameraFollowPlayer()
    {
        m_stopFollow = false;
    }
}
