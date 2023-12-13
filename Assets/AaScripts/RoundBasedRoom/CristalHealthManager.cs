using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CristalHealthManager : MonoBehaviour, IDamageable
{
    [SerializeField] int health;
    [SerializeField] GameObject parentGo;

    private RoundManager roundManager;

    private void Awake()
    {
        roundManager = GameObject.FindAnyObjectByType<RoundManager>().GetComponent<RoundManager>();

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

            Destroy(parentGo);
        }

    }
}
