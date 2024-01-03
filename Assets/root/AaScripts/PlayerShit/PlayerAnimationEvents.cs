using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationEvents : MonoBehaviour
{
    private Animator anim;
    PlayerManager pManager;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        pManager = GetComponent<PlayerManager>();
    }
    private void CanPlayerMoveToFalse()
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
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
    private void Parry()
    {
        GetComponent<PlayerHealth>().TakeDamage(15);
        pManager.isPlayerParry = true;
    }
    private void ParryEnd()
    {
        pManager.isPlayerParry = false;

    }

    private void AaEnd()
    {
        anim.SetTrigger("AaEnd");
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


}
