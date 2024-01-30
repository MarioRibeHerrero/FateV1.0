using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyHealth : MonoBehaviour, IDamageable
{
    private MeleeEnemyState state;
    private RoundManager roundManager;
    private Animator anim;

    private void Awake()
    {
        state = GetComponent<MeleeEnemyState>();
        anim = GetComponent<Animator>();
        roundManager = FindAnyObjectByType<RoundManager>();
        
    }

    public void TakeDamage(int damage)
    {

        state.health -= damage;
        CheckHealth();
        anim.SetTrigger("Hit");
    }




    public bool isDead;
    private void CheckHealth()
    {
        if (state.health <= 0)
        {
            //Aqui hacer cosas de object booling

            

            if(!isDead && roundManager != null) RoudRoomShit();

            //no se usa xq ahora lo llamo con delagados desde el roundmanager
            anim.SetTrigger("Die");

        }
    }

    private void RoudRoomShit()
    {
        isDead = true;
        roundManager.roundRoomEnemies.Remove(gameObject);
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
