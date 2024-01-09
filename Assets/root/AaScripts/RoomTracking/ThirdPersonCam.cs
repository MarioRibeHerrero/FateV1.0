using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ThirdPersonCam : MonoBehaviour
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
        GameManager.Instance.thirdPersonCam = true;
    }
    private void SwitchToNormal()
    {
        ActivateNormalActionMap();
        GameManager.Instance.thirdPersonCam = false;
    }
    private void ActivateThirdPersonActionMap()
    {
        playerInput.SwitchCurrentActionMap("ThirdPersonMovement");
    }
    private void ActivateNormalActionMap()
    {
        playerInput.SwitchCurrentActionMap("PlayerNormalMovement");
    }
}
