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
        FMODUnity.RuntimeManager.PlayOneShot("event:/Jump");
    }
}