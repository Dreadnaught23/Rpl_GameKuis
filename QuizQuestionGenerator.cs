using UnityEngine;

public class QuizQuestionGenerator : MonoBehaviour
{
    public QuizQuestionScriptableObject[] pertanyaan;

    public QuizQuestionScriptableObject CreateQuestion(string questionText, string[] answerOptions, int correctAnswerIndex, Sprite imageQuestion, string questionTextEng, string[] answerOptionsEng)
    {
        QuizQuestionScriptableObject question = ScriptableObject.CreateInstance<QuizQuestionScriptableObject>();
        question.questionText = questionText;
        question.questionTextEng = questionTextEng;

        question.answerOptions = answerOptions;
        question.answerOptionsEng = answerOptionsEng;

        question.correctAnswerIndex = correctAnswerIndex;
        question.questionImage = imageQuestion;
        return question;
    }
}

