using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemyAttack : MonoBehaviour
{

    [SerializeField] GameObject parent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(parent.GetComponent<FlyingEnemyPath>().AttackPlayer(other));
        }
    }
}
