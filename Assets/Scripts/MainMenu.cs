using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void play()
    {
        SceneManager.LoadScene("LevelSelection");
    }

    public void options()
    {
        SceneManager.LoadScene("Options");
    }

    public void signOut() 
    {
        SceneManager.LoadScene("Login");
    }

    public void Home()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
