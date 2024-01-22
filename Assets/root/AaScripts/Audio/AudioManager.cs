using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Audio Source References")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;

    [Header("Audio Clip Arrays")]
    public AudioClip[] musiclist;
    public AudioClip[] sfxlist;


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

    public void PlayMusic(int musicIndex)
    {
        musicSource.clip = musiclist[musicIndex];
        musicSource.Play();
    }

    public void PlayerSFX(int sfxIndex)
    {
        sfxSource.PlayOneShot(sfxlist[sfxIndex]);
    }

    public void EditMusicVolume(float vol)
    {
        musicSource.volume = vol;

    }

    public void EditSfxVolume(float vol)
    {
        sfxSource.volume = vol;
    }
}