using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 


public class LevelManager : MonoBehaviour
{

    public EnemyMovement[] enemy;
    public Transform startPoint;
    public Transform[] path;

    public GameObject quizUI;
    public int EQ;
    public int IQ;
    public int waveTracker = 1;
    public TextMeshProUGUI quizIQRewardText;

    public EnemySpawner enemySpawner;
    public QuizManager quizManager;


    public static LevelManager main;

    private void Awake()
    {
        main = this;
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        // get current wave of game
        int currentWave = enemySpawner.GetCurrentWave();
        Debug.Log("Current wave: " + currentWave);
        Debug.Log("Wave Tracker: " + waveTracker);

        // if last quiz is has not been answered yet
        if (!quizManager.isLastQuizShown)
        {
            // check if current wave has been updated
            if (currentWave != waveTracker)
            {
                waveTracker++;
                int iqReward = quizManager.iqReward;
                int levelReached = quizManager.levelReached;
                
                // start quiz again
                StartCoroutine(StartQuiz(iqReward, levelReached));

            }
        }
        else 
        {
            // if last quiz has been answered
            // check if current wave has been updated to latest
            if (currentWave == waveTracker + 1) 
            {
                // execute startwave again to display victory
                enemySpawner.StartCoroutine(enemySpawner.StartWave());
                enabled = false;
            }
        }
        
    }

    // start quiz
    public IEnumerator StartQuiz(int iqReward, int level)
    {
        yield return new WaitForSeconds(2);
        
        // disble enemy movement and set question here
        // if set question on quizManager, setCurrentQuestion will be called twice
        isEnemyMovementEnabled(false);
        quizManager.SetCurrentQuestion();

        // Show the quiz UI
        quizUI.SetActive(true);

        // Set total waves for the game based on level
        enemySpawner.SetTotalWavesToWin(level);

        // Set IQ and EQ reward texts
        /*quizIQRewardText.text = "IQ Reward: " + iqReward;*/

    }

    public void EndQuiz(bool isQuizCompleted)
    {
        // Reset animatio, set question and disable quiz
        quizManager.ResetAnimtor();
        quizManager.SetCurrentQuestion();
        quizUI.SetActive(false);

        // enable enemy movement
        isEnemyMovementEnabled(true);
      
        // start wave 
        StartCoroutine(enemySpawner.StartWave());


        // ... (other logic for wave start or other actions)
    }

    public void IncreaseIQ(int amount)
    {
        IQ += amount;
    }

    public bool SpendIQ(int amount)
    {
        if (amount <= IQ)
        {
            IQ -= amount;
            return true;
        }
        else
        {
            Debug.Log("Not enuf");
            return false;
        }
    }

    // decrease eq ingame
    public void DecreaseEQ(int amount)
    {
        // if enemy EQ deduct from original EQ is less than 0 (eg: -5), set value to 0
        // else, deduct normally
        if ((EQ -= amount) < 0)
        {
            EQ = 0;
        }
        else 
        {
            EQ -= amount;
        }

        Debug.Log("Current EQ: " + EQ);

        if (EQ == 0)
        {
            CallGameOver();
        }
    }

    // function to disable and enable enemy movement
    private bool isEnemyMovementEnabled(bool status) 
    {
        if (status)
        {
            for (int i = 0; i < enemy.Length; i++)
            {
                Debug.Log("Initialise enemy movement");
                enemy[i].isMovementEnabled = true;
            }
            return true;
        }
        else 
        {
            for (int i = 0; i < enemy.Length; i++)
            {
                Debug.Log("Initialise enemy movement");
                enemy[i].isMovementEnabled = false;
            }
            return false;
        }
    }

    public void CallGameOver() 
    {
        Debug.Log("Game Over");
        GameOverMenu.isGameOver = true;
    }

}
