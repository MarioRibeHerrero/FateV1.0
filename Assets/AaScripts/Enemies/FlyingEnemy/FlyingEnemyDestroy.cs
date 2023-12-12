using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemyDestroy : MonoBehaviour, IDamageable
{

    [SerializeField] Transform dashPack;
    [SerializeField] Transform flyingEnemy;
    private FlyingEnemyHealth healthS;
    private FlyingEnemyState state;

    private void Awake()
    {


        healthS = dashPack.GetComponent<FlyingEnemyHealth>();
        state = dashPack.GetComponent<FlyingEnemyState>();


    }


    public void TakeDamage(int damage)
    {
        healthS.health -= damage;
        healthS.CheckHealth();
    }


    private void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.layer == 8)
        {
            TakeDamage(10);
        }

        if (other.CompareTag("Player"))
        {
            if(GameManager.Instance.isPlayerParry)
            {
                this.transform.parent.position = other.transform.Find("FlyingEnemyPos").transform.position;
                flyingEnemy.GetComponent<Rigidbody>().velocity = Vector3.zero;
                other.GetComponent<PlayerHealth>().HealPlayer(15);


            }
            else
            {
                other.GetComponent<PlayerHit>().HitPlayer(this.transform.position, 30, 0.5f, 20, false);
                TakeDamage(10);

            }

        }





    }
}
