using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCallAnimationEvents : MonoBehaviour
{
    [SerializeField] Animator anim;






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
}
