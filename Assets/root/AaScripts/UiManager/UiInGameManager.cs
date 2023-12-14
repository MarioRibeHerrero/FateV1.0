using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class UiInGameManager : MonoBehaviour
{
    PlayerInput playerInput;



    //miniMap
    [SerializeField] GameObject miniMap;
    private bool isMiniMapOpen;
    private void Awake()
    {
        //Get Components
        playerInput = GetComponent<PlayerInput>();

    }


    private void Start()
    {
        playerInput.actions["OpenMap"].started += UiInGameManager_started;
    }

    private void UiInGameManager_started(InputAction.CallbackContext obj)
    {
        if(!isMiniMapOpen)
        {
            miniMap.SetActive(true);
            isMiniMapOpen = true;

        }
        else
        {
            miniMap.SetActive(false);
            isMiniMapOpen = false;

        }

    }
}
