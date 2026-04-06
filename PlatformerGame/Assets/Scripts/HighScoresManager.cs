using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class HighScoresManager : MonoBehaviour
{
    public TextMeshProUGUI[] scoreEntries;

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}