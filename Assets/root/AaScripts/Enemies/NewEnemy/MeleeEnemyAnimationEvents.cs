using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class MeleeEnemyAnimationEvents : MonoBehaviour
{
    private MeleeEnemyState stateManager;

    [SerializeField] MeleeEnemyStateController enemyController;

    private void Awake()
    {
        stateManager = GetComponent<MeleeEnemyState>();
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

}
