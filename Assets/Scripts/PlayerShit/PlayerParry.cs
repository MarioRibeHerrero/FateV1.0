using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerParry : MonoBehaviour
{
    PlayerInput playerInput;
    private Animator anim;

    

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();



        playerInput.actions["Parry"].started += PlayerParry_started;

        anim = GetComponent<Animator>();
    }

    private void PlayerParry_started(InputAction.CallbackContext obj)
    {
        if(GetComponent<PlayerGroundCheck>().isPlayerGrounded && !GameManager.Instance.isOccupied && GameManager.Instance.playerHealth >= 30)
        {
            anim.SetTrigger("Parry");
           
        }
    }


}
