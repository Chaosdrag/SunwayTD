using UnityEngine;

public class QuizTrigger : MonoBehaviour
{
    public LevelManager levelManager; // Reference to the LevelManager script
    public int iqReward = 50; // Define the IQ reward here

    /*private void OnTriggerEnter2D(Collider2D other)
    {
        // This method is called when another Collider enters the trigger zone.

        // Check if the object entering the trigger is the player or has a specific tag
        *//*if (other.CompareTag("Player"))
        {
            Debug.Log("Trigger entered");
            // Provide the required IQ reward when calling StartQuiz
             // Use the defined iqReward value
        }*//*

        

    }*/

   /* private void Start()
    {
        levelManager.StartQuiz(iqReward);
    }*/
}
