using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialEnemyHealth : MonoBehaviour, IDamageable
{


    public void TakeDamage(int damge)
    {
        gameObject.SetActive(false);
    }
}
