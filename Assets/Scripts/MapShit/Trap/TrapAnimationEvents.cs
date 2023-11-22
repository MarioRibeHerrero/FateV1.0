using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapAnimationEvents : MonoBehaviour
{
    public bool attacking;
    private void AttackingToFalse()
    {
        attacking = false;
    }

    private void AttackingToTrue()
    {
        attacking = true;
    }
}
