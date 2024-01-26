using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    //
    public int overallVolume, musicVolume, sfxVolume;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }







    public void PlayPlayerJump()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/PlayerSounds/PlayerJump");
    }
    public void PlayPlayerDobleJump()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/PlayerSounds/PlayerDobleJump");
    }
    public void PlayPlayerAa1()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/PlayerSounds/PlayerAa1");
    }
    public void PlayPlayerAa2()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/PlayerSounds/PlayerA2");
    }
    public void PlayPlayerAa3()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/PlayerSounds/PlayerAa3");
    }
    public void PlayPlayerFootStep()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/PlayerSounds/FootStep");
    }
    public void PlayPlayerChairSit()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/PlayerSounds/PlayerChairSit");
    }
    public void PlayPlayerHit()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/PlayerSounds/PlayerHit");
    }
    public void PlayPlayerLand()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/PlayerSounds/PlayerLand");
    }
    public void PlayPlayerDeath()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/PlayerSounds/PlayerDeath");

    }
}