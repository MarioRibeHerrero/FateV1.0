using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyHealth : MonoBehaviour, IDamageable, IHealPlayer
{
    private BasicEnemyState basicManager;

    private void Awake()
    {
        basicManager = GameObject.FindAnyObjectByType<BasicEnemyState>();
    }
    public void TakeDamage(int damage)
    {
        basicManager.health -= damage;
        CheckHealth();
    }

    private void CheckHealth()
    {
        if (basicManager.health <= 0)
        {
            //Aqui hacer cosas de object booling
            basicManager.gameObject.SetActive(false);
        }
    }
}
