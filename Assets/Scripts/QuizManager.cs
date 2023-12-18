using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    public Question[] questions;
    private static List<Question> unansweredQuestions;

    private Question currentQuestion;
    [SerializeField] private TextMeshProUGUI factText;
    [SerializeField] private TextMeshProUGUI trueAnswerText;
    [SerializeField] private TextMeshProUGUI falseAnswerText;
    [SerializeField] private Animator animator;
    [SerializeField] private float timeBetweenQuestions = 1f;

    public LevelManager levelManager;
    public int iqReward = 50;

    void Start()
    {
        if (unansweredQuestions == null || unansweredQuestions.Count == 0)
        {
            unansweredQuestions = questions.ToList<Question>();
        }

        SetCurrentQuestion();
    }

    void SetCurrentQuestion()
    {
        int randomQuestionIndex = Random.Range(0, unansweredQuestions.Count);   
        currentQuestion = unansweredQuestions[randomQuestionIndex];

        factText.text = currentQuestion.fact;

        if (currentQuestion.isTrue) 
        {
            trueAnswerText.text = "Correct";
            falseAnswerText.text = "Wrong";
        }else
        {
            trueAnswerText.text = "Wrong";
            falseAnswerText.text = "Correct";
        }
    }

    IEnumerator TransitionToNextQuestion()
    {
        unansweredQuestions.Remove(currentQuestion);

        yield return new WaitForSeconds(timeBetweenQuestions);

        if (unansweredQuestions.Count == 0)
        {
            Debug.Log("Re");

            // End the quiz when all questions are answered
            levelManager.EndQuiz();
        }
        else
        {
            Debug.Log("Next Question");
            // Load the next question
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void UserSelectTrue()
    {
        animator.SetTrigger("True");
        if (currentQuestion.isTrue)
        {
            Debug.Log("Correct");
            levelManager.IncreaseIQ(iqReward);
        }
        else
        {
            Debug.Log("Wrong");
        }

        StartCoroutine(TransitionToNextQuestion());
    }

    public void UserSelectFalse()
    {
        animator.SetTrigger("False");
        if (!currentQuestion.isTrue)
        {
            Debug.Log("Correct");
            levelManager.IncreaseIQ(iqReward);
        }
        else
        {
            Debug.Log("Wrong");
        }
        StartCoroutine(TransitionToNextQuestion());
    }

}