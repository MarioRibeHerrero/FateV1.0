using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class BossCallAnimationEvents : MonoBehaviour
{
    [SerializeField] Animator attackAnimator;
     BossFightController bFController;
    private Animator thisAnim;


    private void Awake()
    {
        thisAnim = GetComponent<Animator>();
        bFController = attackAnimator.transform.GetComponent<BossFightController>();
    }

    public string animationToCallNext;


    private void ShowPilarShadow()
    {
        attackAnimator.SetTrigger("ShowShadows");
    }

    private void DashLeftToRight()
    {
        LeanTween.moveLocalX(gameObject, 7.75f, 0.5f);
    }

    private void DashRightToLeft()
    {
        LeanTween.moveLocalX(gameObject, -9.3f, 0.5f);
    }

    private void CallNewAttack()
    {
        bFController.GetRandomBossAttack();
    }
    private void GoAfk()
    {
        this.transform.position = new Vector3(-200,0,0);
    }
    private void CallOnApear()
    {
        this.transform.position = bFController.spawnPos;

        bFController.onApear();
        bFController.onApear = null;
    }

    private void CallLeftToRightBoomerang()
    {
        attackAnimator.SetTrigger("LeftToRightBoomerang");

    }

    private void CallRightToLeftBoomerang()
    {
        attackAnimator.SetTrigger("RightToLeftBoomerang");
    }


    private void ComboRightToLeft()
    {
        LeanTween.moveLocalX(gameObject, -5.5f, 0.33f);
    }
    private void ComboLeftToRIght()
    {
        LeanTween.moveLocalX(gameObject, 4.7f, 0.33f);
    }

    private void CombinedAttackDisk()
    {
        if (bFController.inSecondFace)
        {
            if (Random.Range(1, 11) <= 2) return;
            bFController.CallCombinedAttackDisk();

        }
    }
    private void CombinedAttackPilar()
    {
        if (bFController.inSecondFace)
        {
            if (Random.Range(1, 11) <= 2) return;
            bFController.CallCombinedAttackPilar();

        }
    }
    public void StunBoss()
    {
        LeanTween.cancel(gameObject);
        if (!bFController.stunRight)
        {
            thisAnim.SetTrigger("Stun1");
            transform.position = new Vector3(transform.position.x + 1.5f, transform.position.y, transform.position.z);

        }
        else
        {
            thisAnim.SetTrigger("Stun2");
            transform.position = new Vector3(transform.position.x - 1.5f, transform.position.y, transform.position.z);
        }

    }


}
