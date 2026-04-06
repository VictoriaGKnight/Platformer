using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScoresDisplay : MonoBehaviour
{
    public TextMeshProUGUI[] scoreEntries;

    void Start()
    {
        DisplayHighScores();
    }

    void DisplayHighScores()
    {
        List<HighScoreEntry> highScores = DatabaseManager.Instance.GetTopHighScores();

        for (int i = 0; i < scoreEntries.Length; i++)
        {
            if (i < highScores.Count)
            {
                HighScoreEntry entry = highScores[i];

                scoreEntries[i].text =
                    (i + 1) + ". " +
                    entry.playerName + " - " +
                    entry.score + " - " +
                    entry.completionTime + "s";
            }
            else
            {
                scoreEntries[i].text = (i + 1) + ". ---";
            }
        }
    }
}
