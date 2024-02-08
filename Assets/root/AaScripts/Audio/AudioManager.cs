using FMOD.Studio;
using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Range(0, 1)]
    public float generalVolume;
    [Range(0,1)]
    public float musicVolume;
    [Range(0, 1)]
    public float sfxVolume;

    private Bus generalBus;
    private Bus sfxBus;
    private Bus musicBus;


    FMOD.Studio.EventInstance mainTheme, preBossLoop, levelTheme, secondPhaseBossLoop, bossEntry;

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
        //audioReferences
        secondPhaseBossLoop = FMODUnity.RuntimeManager.CreateInstance("event:/Music/BossFight/SecondPhase");
        bossEntry = FMODUnity.RuntimeManager.CreateInstance("event:/Music/BossFight/BossLoop");
        
        mainTheme = FMODUnity.RuntimeManager.CreateInstance("event:/Music/Game/MainTheme");
        
        preBossLoop = FMODUnity.RuntimeManager.CreateInstance("event:/Music/BossFight/PreBossLoop");
        
        levelTheme = FMODUnity.RuntimeManager.CreateInstance("event:/Music/Game/LevelTheme");


        generalBus = RuntimeManager.GetBus("bus:/");
        musicBus = RuntimeManager.GetBus("bus:/Music");
        sfxBus = RuntimeManager.GetBus("bus:/Sfx");
    }

    private void Update()
    {
        generalBus.setVolume(generalVolume);
        sfxBus.setVolume(sfxVolume);
        musicBus.setVolume(musicVolume);
    }
    private void Start()
    {
        mainTheme.start();
    }

    public void MainMenuIntoLevel1()
    {
        mainTheme.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        levelTheme.start();

    }
    public void LevelTheme()
    {
        StopAllMusic();
        levelTheme.start();
    }
    public void PreBossIntoLevel()
    {
        StopAllMusic();
        levelTheme.start();

    }
    public void LevelIntoPreBoos()
    {
        StopAllMusic();
        preBossLoop.start();

    }
    public void FristPhaseBossFight()
    {
        StopAllMusic();
        bossEntry.start();
    }
    
    public void SecondPhaseTransition()
    {
        StopAllMusic();
        secondPhaseBossLoop.start();

    }
    
    
    
    public void StopAllMusic()
    {
        mainTheme.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        preBossLoop.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        levelTheme.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        bossEntry.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        secondPhaseBossLoop.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);

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