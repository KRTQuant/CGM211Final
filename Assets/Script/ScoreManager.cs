using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int score;
    public Text scoreText;
    private void Start()
    {
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
    }
    void Update()
    {

    }

    public void UpdateScore(int Gotscore)
    {
        score += Gotscore;
        Debug.Log(score);
        scoreText.text = "Score : " + score.ToString("F0");
    }
}
