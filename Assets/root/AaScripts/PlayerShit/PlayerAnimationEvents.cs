using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAnimationEvents : MonoBehaviour
{
    private Animator anim;
    [SerializeField] GameObject player;
    PlayerManager pManager;
    Rigidbody rb;
    PlayerHealth pHealth;
    PlayerHook pHook;
    PlayerAa pAa;
    private PlayerSpawnPoint playerSpawnPoint;
    private PlayerInput pInput;
    private PlayerRotation pRotation;



    [Header("PARTICLE SYSTEM")]

    [SerializeField] ParticleSystem aa1, aa2;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        pManager = player.GetComponent<PlayerManager>();
        rb = player.GetComponent<Rigidbody>();
        pHealth = player.GetComponent<PlayerHealth>();
        pHook = player.GetComponent<PlayerHook>();
        pAa = player.GetComponent<PlayerAa>();
        pRotation = player.GetComponent<PlayerRotation>();
        pInput = player.GetComponent<PlayerInput>();
        playerSpawnPoint = player.GetComponent<PlayerSpawnPoint>();
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

        anim.SetBool("HasHitEnemy", false);


    }


    private void CheckIfGoingToFirstAttack()
    {

        pAa.goToFirstAaCheck = true;
        pAa.goToSecondAaCheck = false;
        anim.SetBool("goToSecondAttack", false);

        anim.SetBool("goToFirstAttack", false);

    }





    private void InStrongAttackToTrue()
    {
        pManager.playerCurrentDamage *= 2;

        pManager.inStrongAttack = true;
    }
    private void InStrongAttackToFalse()
    {
        pManager.playerCurrentDamage = 20;


        pManager.inStrongAttack = false;
        pManager.canGoToThirdAttack = false;

        anim.SetBool("goToThirdAttack", false);
        anim.SetBool("HasHitEnemy", false);

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







    private void SfxAa1()
    {
        aa1.Play();
        AudioManager.Instance.PlayPlayerAa1();
    }
    private void SfxAa2()
    {
        aa2.Play();
        AudioManager.Instance.PlayPlayerAa2();

    }
    private void SfxAa3()
    {
        AudioManager.Instance.PlayPlayerAa3();

    }

    private void SfxParry()
    {
        AudioManager.Instance.PlayPlayerParry();

    }
    private void SfxStairs()
    {
        AudioManager.Instance.PlayPlayerStairs();

    }
    private void SfxHook()
    {
        AudioManager.Instance.PlayPlayerHook();

    }

    private void SfxFootStep()
    {
        AudioManager.Instance.PlayPlayerFootStep();

    }

    private void SfxChairSeat()
    {
        AudioManager.Instance.PlayPlayerChairSit();


    }

    private void ChairSeatEnd()
    {
        playerSpawnPoint.SetSpawnPoint();
        pInput.SwitchCurrentActionMap("PlayerNormalMovement");
        pManager.playerSitting = false;

    }


}
