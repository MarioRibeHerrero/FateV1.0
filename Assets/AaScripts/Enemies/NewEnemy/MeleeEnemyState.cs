using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyState : MonoBehaviour
{
    public delegate void Reset();
    public Reset onEnemyReset;

    public enum MeleeEnemyStateEnum
    {
        Pathing,
        Tracking,
        Waiting,
        Attacking,
        Stunned
    }
    public MeleeEnemyStateEnum state;
    public float health;
    public float healthOnRespawn;
    public bool playerInMovingZone;

    private void Start()
    {
        onEnemyReset += ResetS;
    }
    private void ResetS()
    {
        health = healthOnRespawn;
    }


    public void CallReset()
    {
        Invoke("qcutre", 0.1f);
    }

    private void qcutre()
    {
        Debug.Log("HOLA");
        onEnemyReset();

    }
}
