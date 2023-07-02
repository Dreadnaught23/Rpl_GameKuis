using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizUIManager : MonoBehaviour
{
    public Image bgTextPertanyaan;
    public Image bgTextPrtnyyanGbr;

    public Text textPertanyaan;
    public Text textPertanyaanGbr;
    public Button[] optionButtons;
    public Image imageSprite;
    public Image bgImageSprite;
    public QuizQuestionGenerator questionGenerator;

    private LocaleSelector localeSelector;
    private QuizQuestionScriptableObject[] pertanyaan;
    private List<int> questionIndices;
    private int currentQuestionIndex;
    private int[] shuffledOptionsIndices;

    private const int maxQUestionsToShow = 10;
    private int questionsShown = 0;
    private int jawabanBenar = 0;
    private string resultSceneName = "HasilScene";

    private void Start()
    {
        questionGenerator = GetComponent<QuizQuestionGenerator>();
        FindObjectOfType<AudioManager>().Play("LaguKuis");

        pertanyaan = questionGenerator.pertanyaan;
        questionIndices = GenerateRandomIndices(pertanyaan.Length);
        currentQuestionIndex = UnityEngine.Random.Range(0,questionIndices.Count);
        shuffledOptionsIndices = new int[optionButtons.Length];
        TampilkanPertanyaan();

    }

    private void TampilkanPertanyaan()
    {
        if (currentQuestionIndex < 0 || currentQuestionIndex >= questionIndices.Count)
        {
            Debug.LogError("Invalid currentQuestionIndex : " + currentQuestionIndex);
            return;
        }
        if(questionsShown >= maxQUestionsToShow)
        {
            PlayerPrefs.SetInt("QuizScore", jawabanBenar);
            SceneManager.LoadScene(resultSceneName);

            return;
        }
        questionsShown++;

        // Shuffle the answer options using Fisher-Yates algorithm
        System.Random rng = new System.Random();
        for (int i = 0; i < shuffledOptionsIndices.Length; i++)
        {
            shuffledOptionsIndices[i] = i;
        }
        int n = shuffledOptionsIndices.Length;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            int value = shuffledOptionsIndices[k];
            shuffledOptionsIndices[k] = shuffledOptionsIndices[n];
            shuffledOptionsIndices[n] = value;
        }

        QuizQuestionScriptableObject currentQuestion = pertanyaan[questionIndices[currentQuestionIndex]];
        localeSelector = GameObject.FindObjectOfType<LocaleSelector>();
        if (localeSelector != null)
        {
            int localeID = localeSelector.GetLocaleID();
            if (localeID == 0)
            {
                textPertanyaan.text = currentQuestion.questionText;
                if (currentQuestion.questionImage != null)
                {
                    bgTextPertanyaan.gameObject.SetActive(false);
                    bgTextPrtnyyanGbr.gameObject.SetActive(true);

                    textPertanyaanGbr.text = currentQuestion.questionText;
                    imageSprite.sprite = currentQuestion.questionImage;
                    imageSprite.gameObject.SetActive(true);
                }
                else
                {
                    imageSprite.gameObject.SetActive(false);
                    bgTextPertanyaan.gameObject.SetActive(true);
                    bgTextPrtnyyanGbr.gameObject.SetActive(false);
                }
                for (int i = 0; i < optionButtons.Length; i++)
                {
                    if (i < currentQuestion.answerOptions.Length)
                    {
                        int optionIndex = shuffledOptionsIndices[i];
                        optionButtons[i].GetComponentInChildren<Text>().text = currentQuestion.answerOptions[optionIndex];
                        if (currentQuestion.correctAnswerIndex == optionIndex)
                        {
                            optionButtons[i].onClick.RemoveAllListeners();
                            optionButtons[i].onClick.AddListener(() => AnswerQuestion(true));
                        }
                        else
                        {
                            optionButtons[i].onClick.RemoveAllListeners();
                            optionButtons[i].onClick.AddListener(() => AnswerQuestion(false));
                        }
                        optionButtons[i].gameObject.SetActive(true);
                    }
                    else
                    {
                        optionButtons[i].gameObject.SetActive(false);
                    }
                }
                Debug.Log("Indo");
            }
            else if(localeID == 1)
            {
                textPertanyaan.text = currentQuestion.questionTextEng;
                if (currentQuestion.questionImage != null)
                {
                    bgTextPertanyaan.gameObject.SetActive(false);
                    bgTextPrtnyyanGbr.gameObject.SetActive(true);

                    textPertanyaanGbr.text = currentQuestion.questionTextEng;
                    imageSprite.sprite = currentQuestion.questionImage;
                    imageSprite.gameObject.SetActive(true);
                }
                else
                {
                    imageSprite.gameObject.SetActive(false);
                    bgTextPertanyaan.gameObject.SetActive(true);
                    bgTextPrtnyyanGbr.gameObject.SetActive(false);
                }
                for (int i = 0; i < optionButtons.Length; i++)
                {
                    if (i < currentQuestion.answerOptionsEng.Length)
                    {
                        int optionIndex = shuffledOptionsIndices[i];
                        optionButtons[i].GetComponentInChildren<Text>().text = currentQuestion.answerOptionsEng[optionIndex];
                        if (currentQuestion.correctAnswerIndex == optionIndex)
                        {
                            optionButtons[i].onClick.RemoveAllListeners();
                            optionButtons[i].onClick.AddListener(() => AnswerQuestion(true));
                        }
                        else
                        {
                            optionButtons[i].onClick.RemoveAllListeners();
                            optionButtons[i].onClick.AddListener(() => AnswerQuestion(false));
                        }

                        optionButtons[i].gameObject.SetActive(true);
                    }
                    else
                    {
                        optionButtons[i].gameObject.SetActive(false);
                    }
                }
                Debug.Log("English");
            }
        }
        else
        {
            //textPertanyaan.text = currentQuestion.questionText;
        }
        if(currentQuestion.bgImage != null)
        {
            bgImageSprite.sprite = currentQuestion.bgImage;
            bgImageSprite.gameObject.SetActive(true);
        }else
        { 
            bgImageSprite.gameObject.SetActive(false);
        }
        /*for (int i = 0; i < optionButtons.Length; i++)
        {
            if (i < currentQuestion.answerOptions.Length)
            {
                int optionIndex = shuffledOptionsIndices[i];
                optionButtons[i].GetComponentInChildren<Text>().text = currentQuestion.answerOptions[optionIndex];
                if (currentQuestion.correctAnswerIndex == optionIndex)
                {
                    optionButtons[i].onClick.RemoveAllListeners();
                    optionButtons[i].onClick.AddListener(() => AnswerQuestion(true));
                }
                else
                {
                    optionButtons[i].onClick.RemoveAllListeners();
                    optionButtons[i].onClick.AddListener(() => AnswerQuestion(false));
                }

                optionButtons[i].gameObject.SetActive(true);
            }
            else
            {
                optionButtons[i].gameObject.SetActive(false);
            }
        }*/
        currentQuestionIndex++;
        if(currentQuestionIndex >= questionIndices.Count)
        {
            currentQuestionIndex = 0;
        }
    }

    private void AnswerQuestion(bool isCorrectAnswer)
    {
        if (isCorrectAnswer)
        {
            Debug.Log("Benar!");
            jawabanBenar++;
        }
        else
        {
            Debug.Log("Salah!");
        }
        TampilkanPertanyaan();
        FindObjectOfType<AudioManager>().Play("SoalSelanjutnya");
    }

    private List<int> GenerateRandomIndices(int length)
    {
        List<int> indices = new List<int>();
        for (int i = 0; i < length; i++)
        {
            indices.Add(i);
        }

        // Shuffle the indices using Fisher-Yates algorithm
        System.Random rng = new System.Random();
        int n = indices.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            int value = indices[k];
            indices[k] = indices[n];
            indices[n] = value;
        }

        return indices;
    }

}
