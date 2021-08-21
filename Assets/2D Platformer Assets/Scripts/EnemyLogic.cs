using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLogic : MonoBehaviour
{
    [SerializeField]
    private float m_moveSpeed;

    [SerializeField]
    private Transform m_leftPoint, m_rightPoint;

    [SerializeField]
    private SpriteRenderer m_SpriteRenderer;

    [SerializeField]
    private float m_moveTime, m_waitTime;

    private float m_moveCount, m_waitCount;
    private bool m_movingRight;
    private Rigidbody2D m_rigidbody2D;
    private Animator m_animator;

    // Start is called before the first frame update
    void Start()
    {
        m_rigidbody2D = GetComponent<Rigidbody2D>();
        m_animator = GetComponent<Animator>();

        m_leftPoint.parent = null;
        m_rightPoint.parent = null;

        m_moveCount = m_moveTime;
    }

    // Update is called once per frame
    void Update()
    {
        // 
        if (m_moveCount > 0)
        {
            m_moveCount -= Time.deltaTime;

            if (m_movingRight)
            {
                m_SpriteRenderer.flipX = true;
                m_rigidbody2D.velocity = new Vector2(m_moveSpeed, m_rigidbody2D.velocity.y);

                if (transform.position.x > m_rightPoint.position.x)
                {
                    m_movingRight = false;
                }
            }
            else
            {
                m_SpriteRenderer.flipX = false;
                m_rigidbody2D.velocity = new Vector2(-m_moveSpeed, m_rigidbody2D.velocity.y);

                if (transform.position.x < m_leftPoint.position.x)
                {
                    m_movingRight = true;
                }
            }

            if (m_moveCount <= 0)
            {
                m_waitCount = Random.Range(m_waitTime * .75f, m_waitTime * 1.25f);
            }

            m_animator.SetBool("IsMoving", true);
        }
        else if (m_waitCount > 0)
        {
            m_waitCount -= Time.deltaTime;
            m_rigidbody2D.velocity = new Vector2(0f, m_rigidbody2D.velocity.y);

            if (m_waitCount <= 0)
            {
                m_moveCount = Random.Range(m_moveTime * .75f, m_waitTime * .75f);
            }

            m_animator.SetBool("IsMoving", false);
        }
        
    }
}
