using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoseLine : MonoBehaviour
{
    public GameObject endScreen;
    public int scorE;
    public TMP_Text scoreText;
    public GameObject FruitDropManager;
    int bestScore;
    private void Start()
    {
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Score score = FindAnyObjectByType<Score>();
        bestScore = score.bestScore;
        endScreen.SetActive(true);
        scorE = score.score;
        Destroy(FruitDropManager.gameObject);
        scoreText.text = "YOUR SCORE: "+scorE.ToString();
  

    }
}
