using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    [Header("PauseMenuObjs")]
    [SerializeField] GameObject hud, optionsMenu, resumeButton;


    private bool isPaused;

    [Header("HUD")]
    [SerializeField] Slider playerHealthSlider;
    [SerializeField] Image parryCd;
    PlayerInput playerInput;


    private void Awake()
    {
        //InputActions
        playerInput = GetComponent<PlayerInput>();

        playerInput.actions["Pause"].started += UiManager_started;
    }

    private void UiManager_started(InputAction.CallbackContext obj)
    {
        if (isPaused)
        {
            
            playerInput.actions.FindActionMap("PlayerActions").Enable();

            hud.SetActive(true);
            optionsMenu.SetActive(false);
            Time.timeScale = 1f;
            isPaused = false;

        }
        else
        {
            Debug.Log("KEKEK");
            playerInput.actions.FindActionMap("PlayerActions").Disable();
            EventSystem.current.SetSelectedGameObject(resumeButton);
            hud.SetActive(false);
            optionsMenu.SetActive(true);
            Time.timeScale = 0f;
            isPaused = true;

        }
    }

    public void UpdatePlayerHealthSlider()
    {
        playerHealthSlider.value = GameManager.Instance.playerHealth /100;
       // Debug.Log("asdas");
    }



}
