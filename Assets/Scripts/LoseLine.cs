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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        endScreen.SetActive(true);
        Score score = FindAnyObjectByType<Score>();
        scorE = score.score;
        Destroy(FruitDropManager.gameObject);
        scoreText.text = "YOUR SCORE: "+scorE.ToString();

    }
}
