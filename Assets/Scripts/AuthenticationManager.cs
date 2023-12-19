using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Authentication;
using System.Threading.Tasks;
using TMPro;
using System;
using UnityEditor.SearchService;
using UnityEngine.SceneManagement;

public class AuthenticationManager : MonoBehaviour
{

    [SerializeField] private GameObject signInDisplay = default;
    [SerializeField] private TMP_InputField usernameInput= default;
    [SerializeField] private TMP_InputField passwordInput = default;
    [SerializeField] private TextMeshProUGUI errorMessageText;
    public float displayErrorDuration = 5f;
    // Start is called before the first frame update
    async void Start()
    {
        

        errorMessageText.text = "";
        await UnityServices.InitializeAsync();
        bool isSignedIn = AuthenticationService.Instance.IsSignedIn;
        if (isSignedIn)
        {
            /*Debug.Log("Signed in: True");
            signInDisplay.SetActive(false);       */
            SignOut();
        }

    }

    public async void Create()
    {
        string usernameText = usernameInput.text;
        string passwordText = passwordInput.text;
        await SignUpWithUsernameAndPassword(usernameText, passwordText);
    }

    public async void SignIn()
    {
        string usernameText = usernameInput.text;
        string passwordText = passwordInput.text;
        await SignInWithUsernameAndPassword(usernameText, passwordText);
     
    }

    public async void SignOut() 
    {
        await SignOutPlayer();
    }

    // function to sign up with username and password
    async Task SignUpWithUsernameAndPassword(string username, string password)
    {
        try
        {
            // function to create user and insert user to Unity Cloud 
            await AuthenticationService.Instance.SignUpWithUsernamePasswordAsync(username, password);
            Debug.Log("Sign up Successful");
            
            // redirect user to the game's home page
            SceneManager.LoadScene("MainMenu");
        }

        // validation error
        catch (AuthenticationException ex)
        {
            ShowErrorMessage(ex.Message);
        }

        // database related error
        catch (RequestFailedException ex)
        {
            ShowErrorMessage(ex.Message);
        }
    }
    async Task SignInWithUsernameAndPassword(string username, string password)
    {
        try
        {
            await AuthenticationService.Instance.SignInWithUsernamePasswordAsync(username, password);
            Debug.Log("Sign In Successful");
            Debug.Log("Player id: " + AuthenticationService.Instance.PlayerId);
            SceneManager.LoadScene("MainMenu");
            /*SceneManager.LoadScene("Options");*/
        }
        catch (AuthenticationException ex)
        {
            ShowErrorMessage(ex.Message);
        }
        catch (RequestFailedException ex)
        {
            ShowErrorMessage(ex.Message);
        }
    }

    public void ShowErrorMessage(string message)
    {
        errorMessageText.text =message;
        errorMessageText.gameObject.SetActive(true);
        /*Invoke("HideErrorMessage", displayErrorDuration);*/
    }

    private void HideErrorMessage()
    {
        errorMessageText.gameObject.SetActive(false);
    }

    async Task SignOutPlayer()
    {
        try
        {
            await Task.Run(() => AuthenticationService.Instance.SignOut());
            Debug.Log("Sign Out Successful");
            // Add any additional logic you want to perform after signing out
        }
        catch (AuthenticationException ex)
        {
            ShowErrorMessage(ex.Message);
        }
        catch (RequestFailedException ex)
        {
            ShowErrorMessage(ex.Message);
        }
    }

}
