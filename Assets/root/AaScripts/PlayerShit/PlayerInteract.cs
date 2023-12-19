using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{

    //InputActions
    PlayerInput playerInput;

    public delegate void OnInteract();
    public static OnInteract onInteract;

    private void Awake()
    {
        //InputActions
        playerInput = GetComponent<PlayerInput>();

        playerInput.actions["Hook"].started += PlayerSpawnPoint_started;
    }


    private void PlayerSpawnPoint_started(InputAction.CallbackContext obj)
    {
        Debug.Log("JUNALSDM");

        if (onInteract != null)
        {
            onInteract();
        }

    }
}
