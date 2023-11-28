using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyState : MonoBehaviour, IReseteable
{
    public int enemyState;


    //ResetShit
   // [SerializeField] GenericHealth healthGo;
    public int health;

    public void Reset()
    {
        //healthGo.health = health;
    }

    // 1= path, 2= follow player, 3= attacking, 4= stunned, 
}
