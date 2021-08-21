using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class EagleEnemyLogic : MonoBehaviour
{
    public Transform[] points;
    public float moveSpeed;
    private int m_currentPoint;

    public SpriteRenderer sprite;

    public float distanceToAttackPlayer, chaseSpeed;

    private Vector3 attackTarget;

    public float waitAfterAttack;

    private float attackCounter;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < points.Length; i++)
        {
            points[i].parent = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (attackCounter > 0)
        {
            attackCounter -= Time.deltaTime;
        }
        else
        {
            if (Vector3.Distance(transform.position, PlayerLogic.instance.transform.position) > distanceToAttackPlayer)
            {
                attackTarget = Vector3.zero;

                transform.position = Vector3.MoveTowards(transform.position, points[m_currentPoint].position, moveSpeed * Time.deltaTime);

                if (Vector3.Distance(transform.position, points[m_currentPoint].position) < .05f)
                {
                    m_currentPoint++;

                    if (m_currentPoint >= points.Length)
                    {
                        m_currentPoint = 0;
                    }
                }

                if (transform.position.x < points[m_currentPoint].position.x)
                {
                    sprite.flipX = true;
                }
                else if (transform.position.x > points[m_currentPoint].position.x)
                {
                    sprite.flipX = false;
                }
            }
            else
            {
                if (attackTarget == Vector3.zero)
                {
                    attackTarget = PlayerLogic.instance.transform.position;
                }

                transform.position = Vector3.MoveTowards(transform.position, attackTarget, chaseSpeed * Time.deltaTime);

                if (Vector3.Distance(transform.position, attackTarget) <= .1f)
                {
                    attackCounter = waitAfterAttack;
                    attackTarget = Vector3.zero;
                }

            }
        }
    }


}
