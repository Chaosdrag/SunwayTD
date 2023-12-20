using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Collections.LowLevel.Unsafe;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI subjectUI;
    [SerializeField] GameObject previousSubjectArrow;
    [SerializeField] GameObject nextSubjectArrow;

    public Button[] levelButtons;
    public AudioController menuBGM;
    public CloudSave cloudSave;
    public Sprite newLevelSprite;
    public Sprite completedLevelSprite;

    public string level1SceneName;
    public string level2SceneName;
    public string level3SceneName;
    public string level4SceneName;
    public string level5SceneName;

   

    string[] subject = { "English", "Mathematic", "Science", "Geography", "History" };

    void Start()
    {
        if (GameObject.FindGameObjectsWithTag("MenuBGM") != null)
        {
            Debug.Log("Menu BGM found!");
            GameObject[] menuBGMbject = GameObject.FindGameObjectsWithTag("MenuBGM");
            menuBGM = menuBGMbject[0].GetComponent<AudioController>();

        }

        cloudSave.RetrieveAllKeys();
        subjectUI.text = subject[0];
        LoadLevelData();
        previousSubjectArrow.SetActive(false);
        levelButtons[0].onClick.AddListener(delegate { LoadLevel1(subjectUI.text); });
        levelButtons[1].onClick.AddListener(delegate { LoadLevel2(subjectUI.text); });
        levelButtons[2].onClick.AddListener(delegate { LoadLevel3(subjectUI.text); });
        levelButtons[3].onClick.AddListener(delegate { LoadLevel4(subjectUI.text); });
        levelButtons[4].onClick.AddListener(delegate { LoadLevel5(subjectUI.text); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    async void LoadLevelData()
    {

        print("subject ui: " + subjectUI.text);

        int levelReached = await cloudSave.LoadData(subjectUI.text);

        print("Level reached: " + levelReached);

        for (int i = 0; i < levelButtons.Length; i++)
        {
            if ((i + 1) > levelReached)
            {
                Debug.Log("disable button: " + i);
                levelButtons[i].interactable = false;
            }
            else
            {
                levelButtons[i].interactable = true;
                levelButtons[i].GetComponent<Image>().sprite = newLevelSprite;
                if ((i + 1) < levelReached || levelReached > levelButtons.Length + 1)
                {
                    levelButtons[i].GetComponent<Image>().sprite = completedLevelSprite;
                }
            }

        }
    }

    // function to change text to previous subject
    public void ChangeToPreviousSubject()
    {
        // get current index of subject
        int currentIndex = Array.IndexOf(subject, subjectUI.text);

        Debug.Log("Current Index: " + currentIndex);

        // make new index subtract 1 to change to previous subject
        int newIndex = currentIndex - 1;

        // if current subject is mathematic (before first subject), change to previous subject
        // and make previous button invisible
        if (newIndex == 0)
        {
            subjectUI.text = subject[newIndex];
            previousSubjectArrow.SetActive(false);
        }

        // if current subject is history (final subject), change to previous subject
        // and make next button visible
        else if (currentIndex == (subject.Length - 1))
        {
            subjectUI.text = subject[newIndex];
            nextSubjectArrow.SetActive(true);
        }

        // change text to previous subject
        else
        {
            subjectUI.text = subject[newIndex];
        }

        LoadLevelData();

    }

    // function to change text to next subject
    public void ChangeToNextSubject()
    {
        // get current index of subject
        int currentIndex = Array.IndexOf(subject, subjectUI.text);

        Debug.Log("Current Index: " + currentIndex);

        // make new index add 1 to change to next subject
        int newIndex = currentIndex + 1;

        // if current subject is english, change text to next subject
        // and make previous button visible
        if (currentIndex == 0)
        {
            subjectUI.text = subject[newIndex];
            previousSubjectArrow.SetActive(true);
        }

        // if current subject is geography (before last subject), change text to next subject
        // and make next button invisible
        else if (newIndex == (subject.Length - 1))
        {
            subjectUI.text = subject[newIndex];
            nextSubjectArrow.SetActive(false);
        }

        // change text to next subject
        else
        {
            subjectUI.text = subject[newIndex];
        }

        LoadLevelData();
    }

    private void LoadLevel1(string subject)
    {
        // save subject as subject chosen
        // save value as 1 since this function is level 1

        cloudSave.subject = subject;
        cloudSave.value = 1;
        Debug.Log("cloudsave subject: " + cloudSave.subject);

        // store this cloudsave to dontdestroyonload and reference it on next scene
        DontDestroyOnLoad(cloudSave);
        Destroy(menuBGM);
        SceneManager.LoadScene(level1SceneName);

    }

    private void LoadLevel2(string subject)
    {
        // save subject as subject chosen
        // save value as 2 since this function is level 2

        cloudSave.subject = subject;
        cloudSave.value = 2;
        Debug.Log("cloudsave subject: " + cloudSave.subject);

        // store this cloudsave to dontdestroyonload and reference it on next scene
        DontDestroyOnLoad(cloudSave);
        Destroy(menuBGM);
        SceneManager.LoadScene(level2SceneName);

    }

    private void LoadLevel3(string subject)
    {
        // save subject as subject chosen
        // save value as 3 since this function is level 3

        cloudSave.subject = subject;
        cloudSave.value = 3;
        Debug.Log("cloudsave subject: " + cloudSave.subject);

        // store this cloudsave to dontdestroyonload and reference it on next scene
        DontDestroyOnLoad(cloudSave);
        Destroy(menuBGM);
        SceneManager.LoadScene(level3SceneName);

    }

    private void LoadLevel4(string subject)
    {
        // save subject as subject chosen
        // save value as 4 since this function is level 4

        cloudSave.subject = subject;
        cloudSave.value = 4;
        Debug.Log("cloudsave subject: " + cloudSave.subject);

        // store this cloudsave to dontdestroyonload and reference it on next scene
        DontDestroyOnLoad(cloudSave);
        Destroy(menuBGM);
        SceneManager.LoadScene(level4SceneName);

    }

    private void LoadLevel5(string subject)
    {
        // save subject as subject chosen
        // save value as 5 since this function is level 5

        cloudSave.subject = subject;
        cloudSave.value = 5;
        Debug.Log("cloudsave subject: " + cloudSave.subject);

        // store this cloudsave to dontdestroyonload and reference it on next scene
        DontDestroyOnLoad(cloudSave);
        Destroy(menuBGM);
        SceneManager.LoadScene(level5SceneName);

    }
}