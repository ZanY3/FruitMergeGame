using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int score;
    public TMP_Text scoreText;
    public int bestScore;
    public TMP_Text bestScoreText;
    public TMP_Text endBestScore;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        var newBestScore = PlayerPrefs.GetInt("BestScore", bestScore);
        endBestScore.text = "Your lastest best score: " + newBestScore.ToString();
        bestScoreText.text = "Your lastest best score: " + newBestScore.ToString();
        score = 0;
        scoreText.text = score.ToString();
    }
    private void Update()
    {
        var newBestScore = PlayerPrefs.GetInt("BestScore", bestScore);
        if (score > newBestScore)
        {
            bestScore = score;
            PlayerPrefs.SetInt("BestScore", bestScore);
            print(bestScore);
        }
        
    }
    public void ScorePlus(int countScore)
    {
        score += countScore;
        scoreText.text = score.ToString();
        
    }
}
