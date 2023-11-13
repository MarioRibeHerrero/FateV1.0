using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyAttack : MonoBehaviour
{
    BasicEnemyPathing ePathing;
    private Animator animator;
    void Start()
    {
        ePathing = transform.parent.GetComponent<BasicEnemyPathing>();
        animator = transform.parent.GetComponent<Animator>();
    }



    public void Attack()
    {
        ePathing.isAttacking = true;
        animator.SetTrigger("Attack");
    }



}
