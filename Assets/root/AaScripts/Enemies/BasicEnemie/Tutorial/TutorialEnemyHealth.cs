using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialEnemyHealth : MonoBehaviour, IDamageable
{

    [SerializeField] GameObject game;
    public void TakeDamage(int damge)
    {
        Invoke("TurnOff",2f);

    }

    private void TurnOff()
    {
        game.SetActive(false);
    }
}
