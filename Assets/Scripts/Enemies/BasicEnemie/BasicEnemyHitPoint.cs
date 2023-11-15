using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyHitPoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            transform.parent.GetComponent<BasicEnemyAttack>().BasicAttack(other);
        }
        if (other.CompareTag("Parry"))
        {
            transform.root.GetComponent<Animator>().SetTrigger("Stunned");
        }

    }
}
