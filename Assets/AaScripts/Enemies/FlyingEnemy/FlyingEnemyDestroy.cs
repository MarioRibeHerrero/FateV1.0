using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemyDestroy : MonoBehaviour
{
    private FlyingEnemyHealth healthS;
    private void Awake()
    {
        healthS = GameObject.FindAnyObjectByType<FlyingEnemyHealth>();
    }


    private void OnTriggerEnter(Collider other)
    {
        
        if(other.CompareTag("Ground"))
        {
            healthS.TakeDamage(10);
            
        }

        if (other.CompareTag("Player"))
        {
            if(GameManager.Instance.isPlayerParry)
            {
                this.transform.parent.position = other.transform.Find("FlyingEnemyPos").transform.position;
                transform.parent.GetComponent<Rigidbody>().velocity = Vector3.zero;
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().HealPlayer(15);


            }
            else
            {
                other.GetComponent<PlayerHit>().HitPlayer(this.transform.position, 30, 0.5f, 20, false);
                healthS.TakeDamage(10);

            }

        }





    }
}
