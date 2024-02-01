using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ChangeActionMapOnEnable : MonoBehaviour
{
    PlayerInput playerInput;

    private void Awake()
    {
        playerInput = GameObject.FindAnyObjectByType<PlayerInput>();
    }

    private void OnEnable()
    {
        SwitchToThirdPerson();

    }
    private void OnDisable()
    {
        SwitchToNormal();
    }

    private void SwitchToThirdPerson()
    {
        ActivateThirdPersonActionMap();
    }
    private void SwitchToNormal()
    {
        ActivateNormalActionMap();
    }
    private void ActivateThirdPersonActionMap()
    {
        playerInput.SwitchCurrentActionMap("Dead");
    }
    private void ActivateNormalActionMap()
    {
        playerInput.SwitchCurrentActionMap("PlayerNormalMovement");
    }
}
