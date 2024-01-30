using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] GameObject credits, mainMenu;

    [SerializeField] GameObject creditsExit, mainMenuPlay;


    private EventSystem eventSystem;

    private void Awake()
    {
        eventSystem = EventSystem.current;
    }


    private void Start()
    {
    }
    public void NewMainScene()
    {
        GameManager.Instance.isGameLoaded = false;

       // SceneManager.LoadScene(1);
    }
    public void LoadMainScene()
    {
        GameManager.Instance.isGameLoaded = true;
        //SceneManager.LoadScene(1);

    }

    public void QuitGame()
    {
        Application.Quit();
    }


    public void OpenCredits()
    {
        mainMenu.SetActive(false);
        credits.SetActive(true);
        eventSystem.SetSelectedGameObject(creditsExit);
    }

    public void GoBackToMainMenu()
    {
        credits.SetActive(false);
        mainMenu.SetActive(true);
        eventSystem.SetSelectedGameObject(mainMenuPlay);

    }
}
