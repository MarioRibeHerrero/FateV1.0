using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class FlyingEnemyHealth : MonoBehaviour, IHealPlayer, IDamageable
{
    private FlyingEnemyState flyingManager;

    private void Awake()
    {
        flyingManager = GameObject.FindAnyObjectByType<FlyingEnemyState>();
    }
    public void TakeDamage(int damage)
    {
        flyingManager.health -= damage;
        CheckHealth();
    }

    private void CheckHealth()
    {
        if(flyingManager.health <=0)
        {
            //Aqui hacer cosas de object booling
            flyingManager.gameObject.SetActive(false);
        }
    }
}
