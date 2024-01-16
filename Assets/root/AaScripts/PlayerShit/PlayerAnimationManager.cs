using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour
{
    [SerializeField] Animator anim;


    private enum AnimationStates
    {
        idle,
        run
    }
    [SerializeField] AnimationStates currentState;

    PlayerMovement pMovement;
    PlayerJump pJump;
    PlayerManager pManager;
    PlayerHealth pHealth;
    PlayerAa pAa;




    void Awake()
    {
        pMovement = GetComponent<PlayerMovement>();
        pJump = GetComponent<PlayerJump>();
        pManager = GetComponent<PlayerManager>();
        pHealth = GetComponent<PlayerHealth>();
        pAa = GetComponent<PlayerAa>();
    }

    // Update is called once per frame
    void Update()
    {

        if (pJump.isFalling)
        {
            anim.SetBool("Fall", true);

        }
        else
        {
            anim.SetBool("Fall", false);
            if (pJump.isJumping)
            {
                anim.SetBool("Jump", true);

            }
            else
            {
                anim.SetBool("Jump", false);

            }
        }


        if (pMovement.inputs.x != 0)
        {
            anim.SetBool("Moving", true);
            currentState = AnimationStates.run;
        }
        else
        {
            anim.SetBool("Moving", false);
            currentState = AnimationStates.idle;
        }




        switch (currentState)
        {
            case AnimationStates.idle:
                
                break;

            case AnimationStates.run:

                break;
        }
    }


    public void Parry()
    {
        anim.SetTrigger("Parry");
        pManager.isPlayerParry = true;
        pHealth.TakeDamage(pManager.parryHealingAmmount);
        pAa.aaCombo = 0;
    }

    public void CallAa() 
    {
        anim.SetTrigger("Aa");

    }
   
    public void RepeatAttack()
    {
        pManager.repeatAa = true;
        anim.SetBool("RepeatAttack", true);

    }
    public void CallAaAir()
    {

        anim.SetTrigger("AaAir");

    }

    public void ChangeAaCombo()
    {

        if (pManager.combo == 0)
        {
            anim.SetInteger("AaCombo", pManager.combo);
            anim.SetTrigger("Aa");

        }
        else
        {
            anim.SetInteger("AaCombo", pManager.combo);
            anim.SetTrigger("Aa");
        }
    }

    public void CallPlayerHit()
    {
        anim.SetTrigger("PlayerHit");

    }

    public void CallHookAnim()
    {
        anim.SetTrigger("Hook");

    }
}
