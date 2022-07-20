using System;
using UnityEngine;
using TMPro;

public class SubtractionScores : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Scores.UpdateScores(GetComponent<TMP_Text>(), Constants.SCORES_SUBTRACTION_TOPSCORES, Constants.SCORES_SUBTRACTION_TOPSCORES_NAMES);
    }

    public void UpdateScores()
    {
        Scores.UpdateScores(GetComponent<TMP_Text>(), Constants.SCORES_SUBTRACTION_TOPSCORES, Constants.SCORES_SUBTRACTION_TOPSCORES_NAMES);
    }
}