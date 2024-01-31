using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CristalHealthManager : MonoBehaviour, IDamageable
{
    public int health;
    [SerializeField] GameObject parentGo;

    private RoundManager roundManager;

    private void Awake()
    {
       // roundManager = GameObject.FindAnyObjectByType<RoundManager>().GetComponent<RoundManager>();

    }


    public void TakeDamage(int damage)
    {
        health -= damage;
        CheckHealth();
    }


    private void CheckHealth()
    {
        if (health <= 0)
        {
            roundManager.isCristalDestroyed = true;
            gameObject.SetActive(false);
        }

        if (roundManager.roundRoomEnemies.Count <= 0 && roundManager.inRoundRoom && roundManager.isCristalDestroyed)
        {


            if (roundManager.currentRound == 3)
            {
                roundManager.EndRoundRoom();

            }
            else
            {
                int newRound;
                newRound = roundManager.currentRound + 1;
                roundManager.CallUpdateRound(newRound, 2);

            }

        }


    }
}
    
