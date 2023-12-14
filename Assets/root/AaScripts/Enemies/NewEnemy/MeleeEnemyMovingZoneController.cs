using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyMovingZoneController : MonoBehaviour
{
    [SerializeField] MeleeEnemyState stateManager;
    [SerializeField] MeleeEnemyStateController enemyController;


    [SerializeField] LayerMask attackLayer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            stateManager.state = MeleeEnemyState.MeleeEnemyStateEnum.Tracking;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //if(stateManager.state != MeleeEnemyState.MeleeEnemyStateEnum.Attacking) stateManager.state = MeleeEnemyState.MeleeEnemyStateEnum.Pathing;
            enemyController.WaitFor(1);

        }
    }


    private void Update()
    {

        stateManager.playerInMovingZone = Physics.OverlapBox(this.transform.position, this.transform.localScale / 2, Quaternion.identity, attackLayer).Length > 0;


    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(this.transform.position, this.transform.localScale);
    }

}
