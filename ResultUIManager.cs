using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResultUIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    private void Start()
    {
        int correctAnswer = PlayerPrefs.GetInt("QuizScore", 0);
        int totalQuestions = 10;
        int maxScore = 100;

        float percentage = (float)correctAnswer / totalQuestions;
        int score = Mathf.RoundToInt(percentage * maxScore);


        if(score >= 60){
            FindObjectOfType<AudioManager>().Play("Menang");
        }
        else
        {
            FindObjectOfType<AudioManager>().Play("Kalah");
        }
        scoreText.text = score.ToString(); 
    }


}
