using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] UiManager uiManager;
    //InputActions
    PlayerInput playerInput;

    public delegate void OnInteract();
    public static OnInteract onInteract;

    private void Awake()
    {
        //InputActions
        playerInput = GetComponent<PlayerInput>();

        playerInput.actions["Hook"].started += PlayerSpawnPoint_started;
        playerInput.actions["Interact3"].started += InteractThirdPerson;

        playerInput.actions["OpenOptions"].started += PlayerInteract_started;
    }

    private void PlayerInteract_started(InputAction.CallbackContext obj)
    {
        uiManager.OpenPauseMenu();
    }



    
    private void InteractThirdPerson(InputAction.CallbackContext obj)
    {
        if (onInteract != null)
        {
            onInteract();
        }
    }

    private void PlayerSpawnPoint_started(InputAction.CallbackContext obj)
    {

        if (onInteract != null)
        {
            onInteract();
        }


    }


    public void SetNewInteract()
    {
        playerInput.actions["Hook"].started += PlayerSpawnPoint_started;

    }

    public void RemoveCurrentInteract()
    {
        playerInput.actions["Hook"].started -= PlayerSpawnPoint_started;

    }
}
