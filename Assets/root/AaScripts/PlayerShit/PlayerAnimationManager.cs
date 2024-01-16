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

        //añadir linea q resetea aa combo

    }

    public void CallAa() 
    {
        anim.SetTrigger("Aa");
    }


    public void SetGoingToSecondAttack()
    {

        anim.SetBool("goToSecondAttack", true);


    }
    public void SetGoingToFirstAttack()
    {

        anim.SetBool("goToFirstAttack", true);

    }
    public void SetGoingToThirdAttack()
    {

        anim.SetBool("goToThirdAttack", true);

    }



    public void CallAaAir()
    {

        anim.SetTrigger("AaAir");

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
