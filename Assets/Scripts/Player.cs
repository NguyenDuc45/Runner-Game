using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    GameManager gameManager;

    Rigidbody2D _rigidbody;
    public Animator animator;
    public Transform feetPos;
    public LayerMask ground;
    public Collider2D playerCollider;
    public HealthBar healthBar;
    public GameObject gameOverMenu;
    public TextMeshProUGUI finalScore;
    public AudioSource hitSound, gameOverSound;

    public float checkRadius;
    float y1, y2 = 0f;
    float jumpTime = 0.4f, jumpTimeCounter;
    public static int playerHealth;
    bool isGrounded, isJumping, isDead;
    //bool isInvulnerable = false;


    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody2D>();
        playerHealth = 3;
        healthBar.SetMaxHealth(playerHealth);
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, ground);
        healthBar.SetHealth(playerHealth);

        PlayerController();
        PlayerDie();
        checkYAxis();
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer != 8 && isInvulnerable == false && gameObject.transform.position.y > -1.4)
        {
            StartCoroutine(GettingHit());
        }
    }*/

    void PlayerController()
    {
        if (GameManager.isPaused == false && playerHealth > 0)
        {
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
            {
                isJumping = true;
                jumpTimeCounter = jumpTime;
                _rigidbody.velocity = Vector2.up * 5f;
            }

            if (Input.GetKey(KeyCode.Space) && isJumping == true)
            {
                if (jumpTimeCounter > 0)
                {
                    _rigidbody.velocity = Vector2.up * 7f;
                    jumpTimeCounter -= Time.deltaTime;
                }
                else
                {
                    isJumping = false;
                }
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                isJumping = false;
            }

            if (gameObject.transform.position.x < -7)
            {
                gameObject.transform.Translate(Vector3.right * Time.deltaTime);
            }

            if (Input.GetKeyUp(KeyCode.J))
            {
                PlayerHurt();
            }
        }
    }

    void PlayerHurt()
    {
        playerHealth--;
        hitSound.Play();
    }

    void PlayerDie()
    {
        if (playerHealth <= 0)
        {
            playerCollider.isTrigger = true;

            if (isGrounded)
            {
                _rigidbody.velocity = Vector2.up * 15f + Vector2.right * 5f;
            }

            gameObject.transform.Rotate(0f, 0f, -5f);

            if (isDead == false)
            {
                finalScore.text = "Your Score: " + GameManager.distance + "m";
                StartCoroutine(ShowGameOverMenu());
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag.Equals("Barrier")) {
            playerHealth = 0;
            hitSound.Play();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        animator.SetBool("isOnAir", true);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        animator.SetBool("isOnAir", false);
    }

    void checkYAxis()
    {
        y1 = y2;
        y2 = gameObject.transform.position.y;

        if (y1 < y2)
        {
            animator.SetBool("isUp", true);
        } else if (y1 > y2)
        {
            animator.SetBool("isUp", false);
        }
    }

    /*IEnumerator GettingHit()
    {
        Debug.Log("Collided with an object");
        isInvulnerable = true;
        playerCollider.isTrigger = true;
        _rigidbody.velocity = Vector2.up * 15f;
        yield return new WaitForSeconds(0.5f);
        Debug.Log("End of invulnerability");
        isInvulnerable = false;
        playerCollider.isTrigger = false;
    }*/

    IEnumerator ShowGameOverMenu()
    {
        yield return new WaitForSeconds(1);
        gameOverMenu.SetActive(true);
    }
}