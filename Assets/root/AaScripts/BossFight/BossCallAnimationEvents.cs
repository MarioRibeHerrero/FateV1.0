using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class BossCallAnimationEvents : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] BossFightController bFController;
    private Animator thisAnim;

    private void Awake()
    {
        thisAnim = GetComponent<Animator>();
    }

    public string animationToCallNext;


    private void ShowPilarShadow()
    {
        anim.SetTrigger("PilarShadow");
    }
    private void RisePilars()
    {
        anim.SetTrigger("RisePilars");

    }
    private void RemovePilars()
    {
        anim.SetTrigger("RemovePilars");

    }


    private void CallNextAttack()
    {
        this.transform.position = bFController.spawnPos;
        Debug.Log(bFController.spawnPos);
        Debug.Log(this.transform.position);
        thisAnim.SetTrigger(animationToCallNext);
    }
}
