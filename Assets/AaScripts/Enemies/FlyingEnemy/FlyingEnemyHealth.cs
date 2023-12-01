using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class FlyingEnemyHealth : MonoBehaviour
{
    private FlyingEnemyState flyingManager;

    private RoundManager roundManager;

    public int health;


    Transform respawnPos;


    private void Awake()
    {
        flyingManager = GetComponent<FlyingEnemyState>();
        roundManager = FindAnyObjectByType<RoundManager>();

    }


    public void CheckHealth()
    {
        if(health <=0)
        {
            roundManager.roundRoomEnemies.Remove(gameObject);


            int newRound;
            newRound = roundManager.currentRound+1;

            if (roundManager.roundRoomEnemies.Count <= 0) roundManager.CallUpdateRound(newRound, 2);



            if (roundManager.currentRound == 3)
            {
                if (!roundManager.isCristalDestroyed)
                {
                    roundManager.CallRespawn(this.gameObject, respawnPos);
                }
                else
                {

                    //endRound
                    roundManager.EndRoundRoom();

                }
            }

            

            flyingManager.gameObject.SetActive(false);
        }
    }
}
