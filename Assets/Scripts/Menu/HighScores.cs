using System;
using UnityEngine;
using TMPro;

public class HighScores : MonoBehaviour
{
    public void UpdateScoreText()
    {
        if (PlayerPrefs.HasKey(Constants.SCORES_TOPSCORES))
        {
            String[] topScores = PlayerPrefs.GetString(Constants.SCORES_TOPSCORES).Split("/n");
            for (int i = 0; i < 5; i++)
            {
                GameObject.Find(Constants.SCORE_TEXT_SHOP[i]).GetComponent<TMP_Text>().text = topScores[i];
            }
        }
    }
}
