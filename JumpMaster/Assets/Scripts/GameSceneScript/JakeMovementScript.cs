using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JakeMovementScript : MonoBehaviour
{
    public float moveSpeed;
    private float horizontalMove;

    public float jumpForce = 10f; // Zýplama kuvveti
    public float fallThreshold = -0.1f; // 10 santimetre
    private bool isGrounded;
    private Rigidbody2D rb;
    private float groundCheckDelay = 1f; // 3 saniye
    private Coroutine groundCheckCoroutine;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontalMove * moveSpeed * Time.deltaTime, rb.velocity.y);

        Vector2 newScale = transform.localScale;

        if (horizontalMove > 0)
        {
            newScale.x = .2f;
        }
        else if (horizontalMove < 0)
        {
            newScale.x = -.20f;
        }

        transform.localScale = newScale;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;

            // Eðer zýplama kontrolü devam ediyorsa, durdur
            if (groundCheckCoroutine != null)
            {
                StopCoroutine(groundCheckCoroutine);
                groundCheckCoroutine = null;
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;

            // Zýplama kontrolüne baþla
            if (groundCheckCoroutine == null)
            {
                groundCheckCoroutine = StartCoroutine(GroundCheck());
            }
        }
    }

    IEnumerator GroundCheck()
    {
        yield return new WaitForSeconds(groundCheckDelay);

        if (!isGrounded)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        int score = CalculateScore();

        // Skoru PlayerPrefs'e kaydet
        PlayerPrefs.SetInt("Score", score);

        // Yüksek skoru kontrol et ve kaydet
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        if (score > highScore)
        {
            PlayerPrefs.SetInt("HighScore", score);
        }

        // Skor sahnesine geç
        SceneManager.LoadScene("ScoreScene");
    }

    int CalculateScore()
    {
        // Skor hesaplamasýný buraya ekleyin. Örneðin, kat edilen mesafeyi skor olarak kullanabilirsiniz.
        return Mathf.FloorToInt(transform.position.y);
    }
}

