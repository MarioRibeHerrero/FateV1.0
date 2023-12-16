using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationEvents : MonoBehaviour
{
    private Animator anim;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private void CanPlayerMoveToFalse()
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GameManager.Instance.canPlayerMove = false;
    }
    private void CanPlayerMoveToTrue()
    {
        GameManager.Instance.canPlayerMove = true;

    }

    private void IsOcupiedToTrue()
    {
        anim.SetBool("IsOccupied", true);
        GameManager.Instance.isOccupied = true;

    }
    private void IsOcupiedToFalse()
    {
        anim.SetBool("IsOccupied", false);
        GameManager.Instance.isOccupied = false;
    }
    private void CanRotateToTrue()
    {
        anim.SetBool("CanRotate", true);
        GameManager.Instance.canPlayerRotate = true;
    }
    private void CanRotateToFalse()
    {
        anim.SetBool("CanRotate", false);
        GameManager.Instance.canPlayerRotate = false;
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
        GameManager.Instance.isPlayerParry = true;
    }
    private void ParryEnd()
    {
        GameManager.Instance.isPlayerParry = false;

    }

    private void AaEnd()
    {
        anim.SetTrigger("AaEnd");
    }




    private void InStrongAttackToTrue()
    {
        GameManager.Instance.inStrongAttack = true;
    }
    private void InStrongAttackToFalse()
    {
        GameManager.Instance.inStrongAttack = false;

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
