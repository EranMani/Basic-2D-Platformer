using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    public static PlayerLogic instance;

    [SerializeField]
    private float m_moveSpeed;

    [SerializeField]
    private float m_jumpForce;

    private bool m_isGrounded;

    [SerializeField]
    private Rigidbody2D m_rigidBody;

    [SerializeField]
    private Transform m_groundCheckPoint;

    [SerializeField]
    private LayerMask m_groundLayer;

    private bool m_canDoubleJump;

    private Animator m_animator;
    private SpriteRenderer m_spriteRenderer;

    [SerializeField]
    private float m_knockBackLength, m_knockBackForce;

    [SerializeField]
    private float m_bounceForce;

    private float m_knockBackCounter;

    private bool m_stopInput;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        m_animator = GetComponent<Animator>();
        m_spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseMenuLogic.instance.CheckIfGamePaused() || m_stopInput)
        {
            return;
        }

        if (PlayerCanMove())
        {
            PlayerMovement();

            if (Input.GetButtonDown("Jump"))
            {
                PlayerJump();
            }

            if (m_isGrounded)
            {
                m_canDoubleJump = true;
            }
        }
        else
        {
            m_knockBackCounter -= Time.deltaTime;
            if (m_spriteRenderer.flipX)
            {
                m_rigidBody.velocity = new Vector2(m_knockBackForce, m_rigidBody.velocity.y);
            }
            else
            {
                m_rigidBody.velocity = new Vector2(-m_knockBackForce, m_rigidBody.velocity.y);
            }
        }

        PlayerAnimationReaction();
    }

    private bool PlayerCanMove()
    {
        return m_knockBackCounter <= 0;
    }
    private void PlayerMovement()
    {
        m_rigidBody.velocity = new Vector2(m_moveSpeed * Input.GetAxisRaw("Horizontal"), m_rigidBody.velocity.y);

        m_isGrounded = Physics2D.OverlapCircle(m_groundCheckPoint.position, .2f, m_groundLayer);

        if (m_rigidBody.velocity.x < 0)
        {
            m_spriteRenderer.flipX = true;
        }
        else if (m_rigidBody.velocity.x > 0)
        {
            m_spriteRenderer.flipX = false;
        }
    }

    private void PlayerJump()
    {
        if (m_isGrounded)
        {
            m_rigidBody.velocity = new Vector2(m_rigidBody.velocity.x, m_jumpForce);

            AudioManager.instance.PlaySFX(10);
        }
        else
        {
            if (m_canDoubleJump)
            {
                m_rigidBody.velocity = new Vector2(m_rigidBody.velocity.x, m_jumpForce);
                m_canDoubleJump = false;

                AudioManager.instance.PlaySFX(10);
            }
        }
    }

    private void PlayerAnimationReaction()
    {
        m_animator.SetFloat("Movement", Mathf.Abs(m_rigidBody.velocity.x));
        m_animator.SetBool("IsGrounded", m_isGrounded);

        if (!PlayerCanMove())
        {
            m_animator.SetTrigger("Hurt");
        }
    }

    public void KnockBackPlayer()
    {
        m_knockBackCounter = m_knockBackLength;
        m_rigidBody.velocity = new Vector2(0f, m_knockBackForce);
    }

    public void Bounce()
    {
        m_rigidBody.velocity = new Vector2(m_rigidBody.velocity.x, m_bounceForce);
    }

    public void DeactivatePlayer()
    {
        gameObject.SetActive(false);
    }

    public void ActivatePlayer()
    {
        gameObject.SetActive(true);
    }

    public void SetPlayerPosition(Vector3 playerPosition)
    {
        transform.position = playerPosition;
    }

    public Vector3 GetPlayerPosition()
    {
        return transform.position;
    }

    public void StopPlayerInput()
    {
        m_stopInput = true;
    }

    public void GetPlayerInput()
    {
        m_stopInput = false;
    }

    public Rigidbody2D GetPlayerRigidbody()
    {
        return m_rigidBody;
    }
}
