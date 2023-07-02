using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "QuizQuestionScriptableObject" , menuName = "ScriptableObjects/QuizQuestionScriptableObject")]
public class QuizQuestionScriptableObject : ScriptableObject
{

    public string questionText;
    public string[] answerOptions;
    public string questionTextEng;
    public string[] answerOptionsEng;

    public int correctAnswerIndex;
    public Sprite questionImage;
    public Sprite bgImage;

}
