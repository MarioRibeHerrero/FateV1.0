using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    //
    public int overallVolume, musicVolume, sfxVolume;


    FMOD.Studio.EventInstance mainTheme, preBossLoop, levelTheme, bossLoop, bossEntry;

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
        mainTheme = FMODUnity.RuntimeManager.CreateInstance("event:/MainTheme");
        preBossLoop = FMODUnity.RuntimeManager.CreateInstance("event:/LoopPasilloPreBoss");
        levelTheme = FMODUnity.RuntimeManager.CreateInstance("event:/LevelTheme");
        bossLoop = FMODUnity.RuntimeManager.CreateInstance("event:/BossLoop");
        bossEntry = FMODUnity.RuntimeManager.CreateInstance("event:/InicioBoss");


    }
    private void Start()
    {
        mainTheme.start();
    }

    public void MainMenuIntoLevel()
    {
        mainTheme.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        levelTheme.start();

    }
    public void LevelIntoPreBoss()
    {
        levelTheme.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        preBossLoop.start();

    }
    public void PreBossIntoLevel()
    {
        preBossLoop.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        levelTheme.start();

    }
    public void PreBossIntoBossEntry()
    {
        preBossLoop.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        bossEntry.start();
        Invoke(nameof(BossEntryIntoFight), 135);

    }
    public void BossEntryIntoFight()
    {
        mainTheme.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        preBossLoop.start();

    }
    public void Respawn()
    {
        mainTheme.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        preBossLoop.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        levelTheme.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        bossEntry.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        bossLoop.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        levelTheme.start();

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