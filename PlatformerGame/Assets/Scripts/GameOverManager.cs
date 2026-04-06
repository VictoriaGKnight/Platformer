/*
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverManager : MonoBehaviour
{
    public TextMeshProUGUI finalScoreText;

    void Start()
    {
        if (GameManager.Instance != null)
        {
            int finalScore = GameManager.Instance.Score;

            finalScoreText.text = "Final Score: " + finalScore;

            DatabaseManager.Instance.SaveScore("Player1", finalScore, Time.time);
        }
    }

    public void TryAgain()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.ResetGame();
        }

        SceneManager.LoadScene("GameScene");
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
*/

using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverManager : MonoBehaviour
{
    public TextMeshProUGUI finalScoreText;
    public TMP_InputField playerNameInput;

    private float completionTime;

    void Start()
    {
        if (GameManager.Instance != null)
        {
            finalScoreText.text = "Final Score: " + GameManager.Instance.Score;
        }

    
        completionTime = Time.time;
    }

    public void SubmitScore()
    {
        if (DatabaseManager.Instance != null && GameManager.Instance != null)
        {
            string playerName = playerNameInput.text;

            if (string.IsNullOrWhiteSpace(playerName))
            {
                playerName = "Player";
            }

            DatabaseManager.Instance.SaveScore(
                playerName,
                GameManager.Instance.Score,
                completionTime
            );

            Debug.Log("Score submitted for: " + playerName);
        }
    }

    public void TryAgain()
    {
        SubmitScore();

        if (GameManager.Instance != null)
        {
            GameManager.Instance.ResetGame();
        }

        SceneManager.LoadScene("GameScene");
    }

    public void ReturnToMenu()
    {
        SubmitScore();
        SceneManager.LoadScene("MainMenu");
    }
}