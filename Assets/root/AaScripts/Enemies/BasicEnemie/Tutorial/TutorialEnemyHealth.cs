using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialEnemyHealth : MonoBehaviour, IDamageable
{

    [SerializeField] GameObject game;
    [SerializeField] int health;
    public void TakeDamage(int damge)
    {
        health -= damge;
        if (health < 0) TurnOff();
    }

    private void TurnOff()
    {
        game.SetActive(false);
    }
}
