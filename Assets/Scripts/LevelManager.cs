using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 


public class LevelManager : MonoBehaviour
{
    public static LevelManager main;

    public Transform startPoint;
    public Transform[] path;

    public GameObject quizUI;
    public int EQ;
    public int IQ;
    public TextMeshProUGUI quizIQRewardText;

    private void Awake()
    {
        main = this;
    }

    private void Start()
    {
        quizUI.SetActive(false);

    }

    public void StartQuiz(int iqReward)
    {
        // Show the quiz UI
        quizUI.SetActive(true);

        // Set IQ and EQ reward texts
        quizIQRewardText.text = "IQ Reward: " + iqReward;

    }

    public void EndQuiz()
    {
        // Hide the quiz UI
        quizUI.SetActive(false);

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
            Debug.Log("Game Over");
            GameOverMenu.isGameOver = true;
        }
    }
}
