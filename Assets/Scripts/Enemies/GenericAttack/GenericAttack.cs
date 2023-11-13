using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericAttack : MonoBehaviour
{
    [SerializeField] int damage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") )
        {
            other.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
        if (other.CompareTag("Parry"))
        {
            transform.root.GetComponent<Animator>().SetTrigger("Stunned");
        }

    }
}
