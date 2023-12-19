using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject plots;
    [SerializeField] GameObject pauseButton;
    [SerializeField] Sprite pausedSprite;
    [SerializeField] Sprite resumedSprite;

    public static bool gameIsPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else 
            {
                Pause();
            }
        }
    }

    public void Home()
    {
        Time.timeScale = 1f;
    }

    // function to pause game
    public void Pause()
    {
        // set pause button to be active
        pauseButton.GetComponent<Image>().sprite = pausedSprite;

        // set pause menu active
        pauseMenu.SetActive(true);

        // freeze game
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void Resume()
    {
        pauseButton.GetComponent<Image>().sprite = resumedSprite;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }



    // See if we need restart function
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }
}
