using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDashAttack : MonoBehaviour
{
    [SerializeField] Animator bodyAnimator;

    public void LeftToRightAttack()
    {
        bodyAnimator.SetTrigger("LeftToRightDash");
    }

    public void RightToLeftAttack()
    {
        bodyAnimator.SetTrigger("RightToLeftDash");

    }


}
