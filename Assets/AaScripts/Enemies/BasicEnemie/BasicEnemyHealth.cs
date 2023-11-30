using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyHealth : MonoBehaviour, IDamageable
{
    private MeleeEnemyState state;
    private RoundManager roundManager;

    private void Awake()
    {
        state = GetComponent<MeleeEnemyState>();

        roundManager = FindAnyObjectByType<RoundManager>();
        
    }

    private void Start()
    {
        
    }
    public void TakeDamage(int damage)
    {
        state.health -= damage;
        CheckHealth();
    }

    private void CheckHealth()
    {
        if (state.health <= 0)
        {
            //Aqui hacer cosas de object booling

            roundManager.roundRoomEnemies.Remove(gameObject);
            if (roundManager.roundRoomEnemies.Count <= 0) roundManager.CallUpdateRound(2, 2);

            //no se usa xq ahora lo llamo con delagados desde el roundmanager
            gameObject.SetActive(false);


        }
    }



}
