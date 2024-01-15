using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PopUpMapChanger : MonoBehaviour
{

    [SerializeField] PlayerInput playerInput;


    [SerializeField] PopUpController popUpController;

    private InputActionMap oldMap;
    private void OnEnable()
    {
        oldMap = playerInput.currentActionMap;

        playerInput.SwitchCurrentActionMap("PopUps");
        playerInput.actions["ExitPopUp"].started += PopUpMapChanger_started;

    }

    private void PopUpMapChanger_started(InputAction.CallbackContext obj)
    {
        popUpController.ExitPopUp();
    }

    private void OnDisable()
    {
        playerInput.actions["ExitPopUp"].started -= PopUpMapChanger_started;
    
        playerInput.SwitchCurrentActionMap(oldMap.name);

    }


}
