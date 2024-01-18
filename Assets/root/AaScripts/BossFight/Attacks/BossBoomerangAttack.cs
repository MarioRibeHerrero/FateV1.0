using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBoomerangAttack : MonoBehaviour
{

    [SerializeField] Animator bodyAnimator;

    public void LeftSideAttact()
    {
        bodyAnimator.SetTrigger("LeftSideBoomerang");
    }

    public void RightSideAttact()
    {
        bodyAnimator.SetTrigger("RightSideBoomerang");

    }
}
