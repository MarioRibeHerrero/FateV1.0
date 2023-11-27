using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemieAnimationEvents : MonoBehaviour
{
    private Animator anim;
    [SerializeField] BasicEnemyPathing ePathing;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }



    public void IsAttackingToTrue()
    {
        ePathing.isAttacking = true;
    }

    public void IsAttackingToFalse()
    {
        ePathing.isAttacking = false;
    }
    public void IsStunnedToTrue()
    {
        ePathing.stunned = true;
    }
    public void IsStunnedToFalse()
    {
        ePathing.stunned = false;
      //  Debug.Log("GOALdasd");
    }
}
