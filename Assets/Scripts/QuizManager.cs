using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class QuizManager : MonoBehaviour
{
    public Question[] questions;
    private static List<Question> unansweredQuestions;

    private Question currentQuestion;

    void Start()
    {
        if (unansweredQuestions == null || unansweredQuestions.Count == 0)
        {
            unansweredQuestions = questions.ToList<Question>();
        }

        GetRandomQuestion();
        Debug.Log(currentQuestion.fact + " is " + currentQuestion.isTrue);
    }

    void GetRandomQuestion()
    {
        int randomQuestionIndex = Random.Range(0, unansweredQuestions.Count);   
        currentQuestion = unansweredQuestions[randomQuestionIndex];

        unansweredQuestions.RemoveAt(randomQuestionIndex);
    }
}