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
        Debug.Log("KEKEKE");
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
}
