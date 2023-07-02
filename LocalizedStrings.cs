using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "LocalizedString", menuName = "Localization/Localized Strings")]
public class LocalizedStrings : ScriptableObject
{
    [SerializeField] private string[] questionTexts;
    [SerializeField] private string[] answerOptions;

    public string GetQuestionText(int questionID)
    {
        if (questionID >= 0 && questionID < questionTexts.Length)
        {
            return questionTexts[questionID];
        }
        else
        {
            Debug.LogError("Invalid Question ID: " + questionID);
            return string.Empty;
        }
    }

    public string[] GetAnswerOptions(int answerOptionsID)
    {
        if(answerOptionsID >= 0 && answerOptionsID < answerOptions.Length)
        {
            return answerOptions[answerOptionsID].Split(";");
        }
        else
        {
            Debug.LogError("Invalid Anseroptions ID: " + answerOptionsID);
            return new string[0];
        }
    }
}
