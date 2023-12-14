using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollideWithEnemies : MonoBehaviour
{

    [SerializeField] float pushbackForce;
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Calculate pushback direction
            Vector3 pushbackDirection = transform.position - collision.transform.position;
            pushbackDirection.Normalize();

            GetComponent<Rigidbody>().AddForce(pushbackDirection * pushbackForce, ForceMode.Impulse);
            GetComponent<PlayerHealth>().TakeDamage(10);
        }




    }
}
