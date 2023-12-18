using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerParry : MonoBehaviour
{
    PlayerInput playerInput;
    private Animator anim;

    private bool canParry;
    [SerializeField] float parryCooldownAmmount;
    public float parryCooldown;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();



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
        if(GetComponent<PlayerGroundCheck>().isPlayerGrounded  && GameManager.Instance.playerHealth >= 35 && !GameManager.Instance.isPlayerParry && !GameManager.Instance.inStrongAttack) 
        {
            anim.SetTrigger("Parry");
           
        }
    }


}
