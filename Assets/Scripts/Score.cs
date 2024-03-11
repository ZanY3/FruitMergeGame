using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int score;
    public TMP_Text scoreText;
    private void Start()
    {
        score = 0;
        scoreText.text = score.ToString();
    }
    public void ScorePlus()
    {
        score += 4;
        scoreText.text = score.ToString();
    }
}
