using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyActivator : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            transform.parent.GetComponent<BasicEnemyState>().enemyState = 2;
            Destroy(this.gameObject);
        }
    }
}
