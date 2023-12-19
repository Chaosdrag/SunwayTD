using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryMenu : MonoBehaviour
{

    [SerializeField] GameObject victoryMenu;
    [SerializeField] TextMeshProUGUI descriptionUI;

    private GameObject[] cloudSaveObject;
    public CloudSave cloudSave;
    public static bool isGameCompleted = false;

    // Start is called before the first frame update
    void Start()
    {
        // see if object with cloudSave exist 
        if (GameObject.FindGameObjectsWithTag("CloudSave") != null)
        {
            Debug.Log("Cloud Save DontDestroyOnLoad");
            cloudSaveObject = GameObject.FindGameObjectsWithTag("CloudSave");
            cloudSave = cloudSaveObject[0].GetComponent<CloudSave>();

        }
        else
        {
            Debug.Log("No Cloud Save DontDestroyOnLoad");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameCompleted)
        {
            GameVictory();
            enabled = false;
        }
    }

    // function to save data after game is completed
    private async void GameVictory() 
    {
        // retreieve level's subject and value
        string subject = cloudSave.subject;
        int level = cloudSave.value;

        // enable victory menu UI
        victoryMenu.SetActive(true);
        descriptionUI.text = "You have completed Level " + level + " - " + subject;

        // stop game time
        Time.timeScale = 0f;

        // check if user has beaten this level before
        int levelReached = await cloudSave.LoadData(subject);

        // if user has beaten this level before
        if (levelReached > level)
        {   
            // save latest level reached instead of this level
            cloudSave.SaveData(subject, levelReached);
        } 
        else 
        {
            // save new level
            cloudSave.SaveData(subject, level + 1);
        }

        // destory cloudSave object from level selection
        Destroy(cloudSaveObject[0]);
    }

    public void Home() 
    {
        
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }
}
