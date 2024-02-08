using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class MeleeEnemyAnimationEvents : MonoBehaviour
{
    private MeleeEnemyState stateManager;
    Animator anim;
    MeleeEnemyStateController enemyController;

    private void Awake()
    {
        stateManager = GetComponent<MeleeEnemyState>();
        enemyController = GetComponent<MeleeEnemyStateController>();
        anim = GetComponent<Animator>();
    }

    private void CanAttackToTrue()
    {
        stateManager.isStunned = false;
        enemyController.canAttack = true;
        enemyController.patience = 0.7f;
        if(stateManager.playerInMovingZone)
        {
            stateManager.state = MeleeEnemyState.MeleeEnemyStateEnum.Tracking;
        }
        else stateManager.state = MeleeEnemyState.MeleeEnemyStateEnum.Pathing;

    }


    private void StunEnemy()
    {
        stateManager.state = MeleeEnemyState.MeleeEnemyStateEnum.Stunned;

    }


    private void SetToInactive()
    {
        gameObject.SetActive(false);

    }
    private void IsDeadToTrue()
    {

        anim.SetBool("IsDead", true);
    }


    private void VelTo0()
    {
        enemyController.enemyMovementSpeed = 0f;
    }
    private void VelNotTo0()
    {
        enemyController.enemyMovementSpeed = enemyController.enemyMovementSpeedDefault;

    }

}
