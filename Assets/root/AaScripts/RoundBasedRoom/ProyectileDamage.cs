using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectileDamage : MonoBehaviour, IDamageable
{
    // Start is called before the first frame update



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            TakeDamage(10);
        }

        if (other.CompareTag("Player"))
        {
            if (GameManager.Instance.isPlayerParry)
            {

                TakeDamage(10);
                //healFor the parry ammount
                other.GetComponent<PlayerHealth>().HealPlayer(other.GetComponent<PlayerManager>().parryHealingAmmount);

            }
            else
            {
                other.GetComponent<PlayerHit>().HitPlayer(this.transform.position, 30, 0.5f, 20, false);
                TakeDamage(10);

            }

        }
    }

    public void TakeDamage(int damage)
    {

        this.gameObject.SetActive(false);

    }
}
