using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

using TMPro;

public class UiManager : MonoBehaviour
{
    [Header("PauseMenuObjs")]
    [SerializeField] GameObject hud, pauseMenu, pauseMenuResumeButton, optionsMenu, qualityDrop;

    [Header("HUD")]
    [SerializeField] Slider playerHealthSlider;
    [SerializeField] Image parryCd;
    [SerializeField] PlayerInput playerInput;
    PlayerHealth pHealth;
    PlayerManager pManager;

    public static Animator anim;


    [Header("OptionsMenu")]

    [SerializeField] TMP_Dropdown qualityDropDown;
    private void Awake()
    {
        //InputActions
        playerInput.actions["CloseMenu"].started += UiManager_started;


        pHealth = playerInput.transform.GetComponent<PlayerHealth>();
        pManager = playerInput.transform.GetComponent<PlayerManager>();


        anim = GetComponent<Animator>();
    }



    private void UiManager_started(InputAction.CallbackContext obj)
    {
        ClosePauseMenu();
    }

    public void UpdatePlayerHealthSlider()
    {
        playerHealthSlider.value = pManager.playerHealth /100;
    }





    public void ClosePauseMenu()
    {
        playerInput.SwitchCurrentActionMap("PlayerNormalMovement");

        hud.SetActive(true);
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void OpenPauseMenu()
    {
        playerInput.SwitchCurrentActionMap("Menu");

        EventSystem.current.SetSelectedGameObject(pauseMenuResumeButton);
        hud.SetActive(false);
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void OpenOptionsMenu()
    {
        optionsMenu.SetActive(true);
        pauseMenu.SetActive(false);

        EventSystem.current.SetSelectedGameObject(qualityDrop);

    }
    public void CloseOptionsMenu()
    {
        optionsMenu.SetActive(false);
        pauseMenu.SetActive(true);

        EventSystem.current.SetSelectedGameObject(pauseMenuResumeButton);


    }


    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public static void FadeIn()
    {
        anim.SetTrigger("Fade");
    }



    #region Quality


    public void AdjustQuality(int number)
    {
        QualitySettings.SetQualityLevel(number);
    }

    public void AdjustOverallVolume(int number)
    {
        Debug.Log(number);
    }
    public void AdjustSfxVolume(int number)
    {
        Debug.Log(number);
    }
    public void AdjustMusicVolume(int number)
    {
        Debug.Log(number);
    }

    #endregion
}
