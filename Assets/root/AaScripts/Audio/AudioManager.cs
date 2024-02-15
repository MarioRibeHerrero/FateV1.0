using FMOD.Studio;
using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Debug = FMOD.Debug;
using UnityEngine.SceneManagement;
using System.ComponentModel;

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


    FMOD.Studio.EventInstance mainTheme, preBossLoop, levelTheme, secondPhaseBossLoop, bossEntry, fateLowHp;

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
        preBossLoop = FMODUnity.RuntimeManager.CreateInstance("event:/Music/BossFight/PreBossLoop");

        mainTheme = FMODUnity.RuntimeManager.CreateInstance("event:/Music/Game/MainTheme");
        levelTheme = FMODUnity.RuntimeManager.CreateInstance("event:/Music/Game/LevelTheme");

        fateLowHp = FMODUnity.RuntimeManager.CreateInstance("event:/PlayerSounds/LowHp");

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

    public void PlayPlayerParry()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/PlayerSounds/PlayerParry");

    }

    public void PlayPlayerHook()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/PlayerSounds/PlayerHook");

    }

    public void PlayPlayerStairs()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/PlayerSounds/PlayerStairs");

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






    public void PlayOpenMetalDoor()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/MapSounds/OpenMetalDoor");

    }
    public void PlayOpenBossDoor()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/MapSounds/OpenBossDoor");
    }
    public void PlayOpenLock()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/MapSounds/DoorLock");

    }



    public void MenuSfx()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/MapSounds/MenuSfx");

    }





    public void PlayEnemyHit()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/MeleeEnemy/MeleeEnemyHit");

    }
    public void PlayEnemyAttack()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/MeleeEnemy/Attack");

    }

    public void PlayStatueFall()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/MapSounds/StatueFall");

    }

    public void PlayCristalDie()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Cristal/Die");

    }
    public void PlayCristalShook()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Cristal/Attack");

    }
    public void PlayBossBoomerang()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Boss/boomerang");

    }
    public void PlayBossAttack12()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Boss/BossComboAttack1&2");

    }
    public void PlayBossAttack3()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Boss/BossComboAttack3");

    }
    public void PlayBossDash()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Boss/BossDash");

    }

    public void StartPlayerLowHp()
    {
        fateLowHp.start();
    }
    public void StopPlayerLowHp()
    {
        fateLowHp.stop((FMOD.Studio.STOP_MODE.ALLOWFADEOUT));
    }

}