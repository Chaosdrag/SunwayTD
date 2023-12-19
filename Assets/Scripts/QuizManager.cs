using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{

    public CloudSave cloudSave;
    public static List<Question> unansweredQuestions;

    private Question currentQuestion;
    [SerializeField] private TextMeshProUGUI factText;
    [SerializeField] private TextMeshProUGUI trueAnswerText;
    [SerializeField] private TextMeshProUGUI falseAnswerText;
    [SerializeField] private Animator animator;
    [SerializeField] private float timeBetweenQuestions = 1f;

    public LevelManager levelManager;

    public int iqReward = 50;
    private string subject;
    public int levelReached;
    private bool isFirstQuizShown = true;
    public bool isLastQuizShown = false;
    private int totalQuestions;
    

    void Start()
    {
        // see if object with cloudSave exist 
        if (GameObject.FindGameObjectsWithTag("CloudSave") != null)
        {
            GameObject[] cloudSaveObject = GameObject.FindGameObjectsWithTag("CloudSave");
            cloudSave = cloudSaveObject[0].GetComponent<CloudSave>();

        }

        // initialise subject and levelReached from user's data
        subject = cloudSave.subject;
        levelReached = cloudSave.value;

        // Initialise questions
        if (unansweredQuestions == null || unansweredQuestions.Count == 0)
        {
            unansweredQuestions = CheckAndInitialiseSubjectQuestions(subject, levelReached);
            totalQuestions = unansweredQuestions.Count;
        }
        
        // start quiz
        StartCoroutine(levelManager.StartQuiz(iqReward, levelReached));
    }

    // set question in quiz
    public void SetCurrentQuestion()
    {
        if (unansweredQuestions.Count == 0)
        {
            isLastQuizShown = true;
        }
        else {

            // randomise question
            int randomQuestionIndex = Random.Range(0, unansweredQuestions.Count);
            currentQuestion = unansweredQuestions[randomQuestionIndex];

            // replace question text with randomised question 
            factText.text = currentQuestion.fact;


            if (currentQuestion.isTrue)
            {
                trueAnswerText.text = "Correct";
                falseAnswerText.text = "Wrong";
            }
            else
            {
                trueAnswerText.text = "Wrong";
                falseAnswerText.text = "Correct";
            }
        }
    }
        

    IEnumerator TransitionToNextQuestion()
    {
        unansweredQuestions.Remove(currentQuestion);

        yield return new WaitForSeconds(timeBetweenQuestions);

        if (isFirstQuizShown)
        {
            if (totalQuestions - unansweredQuestions.Count == 3)
            {
                levelManager.EndQuiz(true);
                isFirstQuizShown = false;
            }
            else
            {
                Debug.Log("Next Question");
                ResetAnimtor();
                SetCurrentQuestion();
            }
        }
        else 
        {
            levelManager.EndQuiz(true);
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

    public void ResetAnimtor() 
    { 
        animator.Rebind();
        animator.Update(0f);
    }

    // retrieves questions based on user's subject and level reached 
    private List<Question> CheckAndInitialiseSubjectQuestions(string subject, int LevelReached)
    {
        List<Question> subjectQuestions;

        switch (subject)
        {
            case "English":
                subjectQuestions = new English().InitialiseEnglishQuestion(LevelReached);
                break;
            case "Mathematic":
                subjectQuestions = new Mathematic().InitialiseMathQuestion(LevelReached);
                break;
            case "Science":
                subjectQuestions = new Science().InitialiseScienceQuestion(LevelReached);
                break;
            case "Geography":
                subjectQuestions = new Geography().InitialiseGeoQuestion(LevelReached);
                break;
            case "History":
                subjectQuestions = new History().InitialiseHistoryQuestion(LevelReached);
                break;
            default:
                return unansweredQuestions;
        }

        return subjectQuestions;
    }

}