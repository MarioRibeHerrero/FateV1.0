using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationEvents : MonoBehaviour
{
    private Animator anim;
    [SerializeField] GameObject player;
    PlayerManager pManager;
    Rigidbody rb;
    PlayerHealth pHealth;
    PlayerHook pHook;
    PlayerAa pAa;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        pManager = player.GetComponent<PlayerManager>();
        rb = player.GetComponent<Rigidbody>();
        pHealth = player.GetComponent<PlayerHealth>();
        pHook = player.GetComponent<PlayerHook>();
        pAa = player.GetComponent<PlayerAa>();
    }
    private void CanPlayerMoveToFalse()
    {
        rb.velocity = Vector3.zero;
        pManager.canPlayerMove = false;
    }
    private void CanPlayerMoveToTrue()
    {
        pManager.canPlayerMove = true;

    }
    private void CanRotateToTrue()
    {
        anim.SetBool("CanRotate", true);
        pManager.canPlayerRotate = true;
    }
    private void CanRotateToFalse()
    {
        anim.SetBool("CanRotate", false);
        pManager.canPlayerRotate = false;
    }
    private void IsOcupiedToTrue()
    {
        anim.SetBool("IsOccupied", true);
        pManager.playerInNormalAttack = true;

    }
    private void IsOcupiedToFalse()
    {
        anim.SetBool("IsOccupied", false);
        pManager.playerInNormalAttack = false;
    }



    //PARY

    private void CanParryToFalse()
    {
        anim.SetBool("CanParry", false);
    }
    private void CanParryToTrue()
    {
        anim.SetBool("CanParry", true);
    }

    private void ParryEnd()
    {
        pManager.isPlayerParry = false;

    }

    private void CheckIfGoingToSecondAttack()
    {
        pAa.goToSecondAaCheck = true;
        pAa.goToFirstAaCheck = false;

        anim.SetBool("goToSecondAttack", false);

        //pongo lo del 3ro a false
        anim.SetBool("goToThirdAttack", false);
        anim.SetBool("hasHitEnemy", false);


    }


    private void CheckIfGoingToFirstAttack()
    {

        pAa.goToFirstAaCheck = true;
        pAa.goToSecondAaCheck = false;

        anim.SetBool("goToFirstAttack", false);

    }





    private void InStrongAttackToTrue()
    {
        pManager.inStrongAttack = true;
    }
    private void InStrongAttackToFalse()
    {
        pManager.inStrongAttack = false;

    }



    private void CancelAllPlayerEvents()
    {
        InStrongAttackToFalse();
        ParryEnd();
        CanParryToTrue();
        CanRotateToTrue();
        IsOcupiedToFalse();
        CanPlayerMoveToTrue();
    }

    private void Hook()
    {
        pHook.CallHook();
    }
}
