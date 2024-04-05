using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerInstace : MonoBehaviour
{
    [SerializeField] GameObject gameManager, audioManager;

    private void Awake()
    {
        if (GameObject.FindAnyObjectByType<GameManager>() != null) return;
        else
        {
            Instantiate(gameManager);
        }
        if (GameObject.FindAnyObjectByType<AudioManager>() != null) return;
        else
        {
            Instantiate(audioManager);
        }
    }

}
