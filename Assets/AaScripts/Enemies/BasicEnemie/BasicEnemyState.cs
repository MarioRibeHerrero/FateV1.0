using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyState : MonoBehaviour, IReseteable
{
    public int enemyState;
    [SerializeField] int healthOnRespawn = 140;
    //ResetShit
   // [SerializeField] GenericHealth healthGo;
    public int health;

    public void Reset()
    {
        GetComponent<Animator>().SetTrigger("Reset");
        enemyState = 1;
        health = healthOnRespawn;
    }

    // 1= path, 2= follow player, 3= attacking, 4= stunned, 
}
