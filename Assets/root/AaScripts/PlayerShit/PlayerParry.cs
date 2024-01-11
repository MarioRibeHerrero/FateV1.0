using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.Rendering.DebugUI;

public class PlayerParry : MonoBehaviour
{
    PlayerInput playerInput;
    PlayerManager pManager;
    PlayerAnimationManager pAnim;


    //CD no hecho aun
    [SerializeField] float parryCooldownAmmount;
    public float parryCooldown;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        pManager = GetComponent<PlayerManager>();

        playerInput.actions["Parry"].started += PlayerParry_started;

        pAnim = GetComponent<PlayerAnimationManager>();
    }

    private void Update()
    {
        parryCooldown = -Time.deltaTime;
        Mathf.Clamp(parryCooldown, 0, parryCooldownAmmount);
    }

    private void PlayerParry_started(InputAction.CallbackContext obj)
    {
        if(GetComponent<PlayerGroundCheck>().isPlayerGrounded  && pManager.playerHealth >= 35 && !pManager.isPlayerParry && !pManager.inStrongAttack) 
        {
            pAnim.Parry();


        }
    }


}
