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
    [SerializeField] private GameObject pauseMenu, pauseMenuResumeButton;
    [Header("OptionsMenuObjs")]
    [SerializeField] private GameObject optionsMenu, optionsVolume;
    [Header("VolumeMenuObjs")]
    [SerializeField] private GameObject volumeMenu, volumeVolumeSlider;

    [SerializeField] private Slider masterSlider, musicSlider, sfxSlider;
    
    [Header("HUD")] 
    [SerializeField] private GameObject hud;
    [SerializeField] Image playerHealthSlider;
    [SerializeField] PlayerInput playerInput;
    PlayerHealth pHealth;
    PlayerManager pManager;

    public static Animator anim;



    private void Awake()
    {
        //InputActions
        playerInput.actions["CloseMenu"].started += UiManager_started;


        pHealth = playerInput.transform.GetComponent<PlayerHealth>();
        pManager = playerInput.transform.GetComponent<PlayerManager>();


        anim = GetComponent<Animator>();
        
        
        //asdad
        UpdateSfxSlider();
        UpdateMasterSlider();
        UpdateMusiclider();
    }



    private void UiManager_started(InputAction.CallbackContext obj)
    {
        ClosePauseMenu();
    }

    public void UpdatePlayerHealthSlider()
    {
        playerHealthSlider.fillAmount = pManager.playerHealth /100;
    }





    public void ClosePauseMenu()
    {
        CloseVolumeMenu();
        CloseOptionsMenu();
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

        EventSystem.current.SetSelectedGameObject(optionsVolume);

    }
    public void CloseOptionsMenu()
    {
        optionsMenu.SetActive(false);
        pauseMenu.SetActive(true);

        EventSystem.current.SetSelectedGameObject(pauseMenuResumeButton);


    }


    public void OpenVolumeMenu()
    {
        volumeMenu.SetActive(true);
        optionsMenu.SetActive(false);

        EventSystem.current.SetSelectedGameObject(volumeVolumeSlider);

    }
    public void CloseVolumeMenu()
    {
        volumeMenu.SetActive(false);
        optionsMenu.SetActive(true);

        EventSystem.current.SetSelectedGameObject(optionsVolume);


    }

    public void UpdateMasterSlider()
    {
        if (masterSlider.value == 0) masterSlider.value = AudioManager.Instance.generalVolume;
        
        AudioManager.Instance.generalVolume = masterSlider.value;
    }
    public void UpdateMusiclider()
    {
        if (musicSlider.value == 0) musicSlider.value = AudioManager.Instance.musicVolume;
        
        AudioManager.Instance.musicVolume = musicSlider.value;
    }
    public void UpdateSfxSlider()
    {
        if (sfxSlider.value == 0) sfxSlider.value = AudioManager.Instance.sfxVolume;
        
        AudioManager.Instance.sfxVolume = sfxSlider.value;
    }

    
    
    
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public static void FadeIn()
    {
        anim.SetTrigger("Fade");
    }


    public void PlayMenuSfx()
    {
        AudioManager.Instance.MenuSfx();
    }
}
