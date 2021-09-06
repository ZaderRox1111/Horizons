using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public Text scoreText;
    public Text highScoreText;

    public int score = 0;
    public int highscore = 0;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore", 0);
        highScoreText.text = "" + highscore;
        scoreText.text = "" + score;
    }

    public void AddPoint(int scoreAdd)
    {
        score += scoreAdd;
        scoreText.text = "" + score;

        if (highscore < score)
        {
            PlayerPrefs.SetInt("highscore", score);
            highScoreText.text = "" + highscore;
        }
    }
}
