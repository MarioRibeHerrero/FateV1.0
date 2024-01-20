using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    [Header("PauseMenuObjs")]
    [SerializeField] GameObject hud, optionsMenu, resumeButton;

    [Header("HUD")]
    [SerializeField] Slider playerHealthSlider;
    [SerializeField] Image parryCd;
    [SerializeField] PlayerInput playerInput;
    PlayerHealth pHealth;
    PlayerManager pManager;

    [SerializeField] GameObject miniMap;
    private bool isMiniMapOpen;
    public static Animator anim;

    private void Awake()
    {
        //InputActions
        playerInput.actions["CloseMenu"].started += UiManager_started;
        playerInput.actions["OpenMap"].started += UiInGameManager_started;


        pHealth = playerInput.transform.GetComponent<PlayerHealth>();
        pManager = playerInput.transform.GetComponent<PlayerManager>();


        anim = GetComponent<Animator>();
    }

    private void UiManager_started(InputAction.CallbackContext obj)
    {
        CloseOptionsMenu();
    }

    public void UpdatePlayerHealthSlider()
    {
        playerHealthSlider.value = pManager.playerHealth /100;
    }


    private void UiInGameManager_started(InputAction.CallbackContext obj)
    {
        if (!isMiniMapOpen)
        {
            miniMap.SetActive(true);
            isMiniMapOpen = true;

        }
        else
        {
            miniMap.SetActive(false);
            isMiniMapOpen = false;

        }

    }


    public void CloseOptionsMenu()
    {
        Debug.Log("MENU");
        playerInput.SwitchCurrentActionMap("PlayerNormalMovement");

        hud.SetActive(true);
        optionsMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void OpenOptionsMenu()
    {
        Debug.Log("Player");


        playerInput.SwitchCurrentActionMap("Menu");

        EventSystem.current.SetSelectedGameObject(resumeButton);
        hud.SetActive(false);
        optionsMenu.SetActive(true);
        Time.timeScale = 0f;
    }


    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }



    public void SmallBug()
    {
        pHealth.TakeDamage(1000);
    }

    public void BigBug()
    {
        Application.Quit();
    }



    public static void FadeIn()
    {
        anim.SetTrigger("Fade");
    }
}
