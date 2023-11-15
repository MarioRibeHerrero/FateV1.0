using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("GPOIASKM+");
        if (other.CompareTag("Enemy"))
        {
            other.transform.parent.GetComponent<GenericHealth>().TakeDamage(20);
        }
    }
}
