using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerParry : MonoBehaviour
{
    PlayerInput playerInput;
    PlayerManager pManager;
    Animator anim;
    PlayerHealth pHealth;


    //CD no hecho aun
    [SerializeField] float parryCooldownAmmount;
    public float parryCooldown;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        pManager = GetComponent<PlayerManager>();
        pHealth = GetComponent<PlayerHealth>();

        playerInput.actions["Parry"].started += PlayerParry_started;

        anim = GetComponent<Animator>();
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
            anim.SetTrigger("Parry");
            pManager.isPlayerParry = true;
            pHealth.TakeDamage(pManager.parryHealingAmmount);
        }
    }


}
