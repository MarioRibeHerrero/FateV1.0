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


    public void TakeDamage(int damage)
    {
        healthS.health -= damage;
        healthS.CheckHealth();
    }


    private void OnTriggerEnter(Collider other)
    {
        
        if(other.CompareTag("Ground"))
        {
            TakeDamage(10);
            Debug.Log("MUERTEPORPARED");
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
                TakeDamage(10);

            }

        }





    }
}
