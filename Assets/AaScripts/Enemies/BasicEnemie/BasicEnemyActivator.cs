using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyActivator : MonoBehaviour
{
    [SerializeField] BasicEnemyPathing ePathing;
    [SerializeField] GameObject parent;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            parent.GetComponent<BasicEnemyState>().enemyState = 2;
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            parent.GetComponent<BasicEnemyState>().enemyState = 1;
            ePathing.RandomTarget();
            StartCoroutine(ePathing.WaitFor(1));
            
        }
    }

}
