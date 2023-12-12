using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemyState : MonoBehaviour
{



    public enum States
    {
        pathing,
        attacking
    }
    public States currentState;
    public bool inRangeOfShoot;


    public delegate void Reset();
    public Reset onEnemyReset;
    // 1= path, 2= follow player, 3= Shoot, 4= Attack, 5= stunned, 





}
