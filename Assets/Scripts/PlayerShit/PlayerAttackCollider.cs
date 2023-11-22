using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.transform.parent.GetComponent<GenericHealth>().TakeDamage(20);
            //si la vida es mas de 100, no le sumes nada
            if(GameManager.Instance.playerHealth !>= 100) transform.root.GetComponent<PlayerHealth>().HealPlayer(5);

        }
    }
}
