using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{


    [SerializeField] private Slider masterSlider, musicSlider, sfxSlider;


    private void Awake()
    {

        //asdad

    }


    private void OnEnable()
    {
        UpdateSfxSlider();
        UpdateMasterSlider();
        UpdateMusiclider();
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

}
