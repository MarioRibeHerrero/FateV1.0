using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UnlockDobleJump : MonoBehaviour
{

    private PlayerInput pInput;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            pInput = other.GetComponent<PlayerInput>();
            PlayerInteract.onInteract += UnlockDobleJumpM;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInteract.onInteract -= UnlockDobleJumpM;

        }
    }


    private void UnlockDobleJumpM()
    {
        pInput.transform.GetComponent<PlayerManager>().isDobleJumpUnlocked = true;
        GameManager.Instance.dobleJump = true;
        SaveSystem.SaveGameManager(GameManager.Instance);
    }
}
