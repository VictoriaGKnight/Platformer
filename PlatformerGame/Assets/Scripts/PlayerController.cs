using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 12f;

    public TextMeshProUGUI healthText;
    public TextMeshProUGUI scoreText;

    private Rigidbody2D rb;
    private bool isGrounded = false;

    private int health = 100;
    private int score = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        UpdateUI();
    }

    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            health -= 10;
            if (health <= 0)
            {
                health = 0;
                UpdateUI();
                GameOver();
            }
            else
            {
                UpdateUI();
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            score += 10;
            Destroy(other.gameObject);
            UpdateUI();
        }
    }

    void UpdateUI()
    {
        if (healthText != null)
            healthText.text = "Health: " + health;

        if (scoreText != null)
            scoreText.text = "Score: " + score;
    }

    void GameOver()
    {
        PlayerPrefs.SetInt("FinalScore", score);
        PlayerPrefs.Save();

        SceneManager.LoadScene("GameOver");
    }
}