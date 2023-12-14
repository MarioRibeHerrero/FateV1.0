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




    private void Awake()
    {
        flyingManager = GetComponent<FlyingEnemyState>();
        roundManager = FindAnyObjectByType<RoundManager>();

    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        CheckHealth();
    }


    public void CheckHealth()
    {
        if(health <=0)
        {
            roundManager.roundRoomEnemies.Remove(gameObject);
            RoudRoomShit();
            flyingManager.gameObject.SetActive(false);
        }
    }


    private void RoudRoomShit()
    {

        if (roundManager.roundRoomEnemies.Count <= 0 && roundManager.inRoundRoom)
        {

            if (roundManager.currentRound == 3)
            {
                roundManager.EndRoundRoom();

            }else
            {

                int newRound;
                newRound = roundManager.currentRound + 1;
                roundManager.CallUpdateRound(newRound, 2);

            }

        }

    }





}
