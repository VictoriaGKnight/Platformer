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
            finalScoreText.text = "Final Score: " + GameManager.Instance.Score;
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