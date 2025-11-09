using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI noteTypeText;
    [SerializeField] private TextMeshProUGUI scoreText;
    private int currentScore = 0;

    void Start()
    {
        currentScore = 0;
        UpdateScoreDisplay();
    }

    public void UpdateScore(int scoreToAdd)
    {
        currentScore += scoreToAdd;
        UpdateScoreDisplay();
        //Debug.Log("Score updated: " + currentScore);
    }

    private void UpdateScoreDisplay()
    {
        if (scoreText != null)
        {
            scoreText.text = currentScore.ToString();
        }
        else
        {
            Debug.LogWarning("Score Text is not assigned in Inspector!");
        }
    }

    public void HandleScore(string quality)
    {
        //Debug.Log("HandleScore called with: " + quality);
        StartCoroutine(DisplayNoteType(quality));

        if (quality == "miss")
        {
            UpdateScore(0);
        }
        else if (quality == "bad")
        {
            UpdateScore(50);
        }
        else if (quality == "good")
        {
            UpdateScore(100);
        }
        else if (quality == "perfect")
        {
            UpdateScore(200);
        }
    }

    private IEnumerator DisplayNoteType(string type)
    {
        noteTypeText.text = type + "!";
        yield return new WaitForSeconds(0.5f);
    }
}