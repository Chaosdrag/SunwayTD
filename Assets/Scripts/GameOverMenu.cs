using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] GameObject gameOverMenu;

    public static bool isGameOver = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver) 
        {
            GameOver();
        }
    }

    // show game over screen
    private void GameOver() 
    {
        // show game over menu
        gameOverMenu.SetActive(true);

        // freeze game
        Time.timeScale = 0f;
    }

    // button to restart game
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
        isGameOver = false;
    }


    public void Home()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }
}
