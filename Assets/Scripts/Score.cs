using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    public int ballValue;

    private int score;

    private void Start()
    {
        score = 0;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Score:\n " + score;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        score += ballValue;
        UpdateScore();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bomb") 
        {
            score -= ballValue * 2;
            UpdateScore();
        }
    }
}
