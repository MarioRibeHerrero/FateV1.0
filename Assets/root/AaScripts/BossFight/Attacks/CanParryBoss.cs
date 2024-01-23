using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanParryBoss : MonoBehaviour
{
    [SerializeField] BossCallAnimationEvents bossAnim;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            if (!other.GetComponent<PlayerManager>().isPlayerParry)
            {
                other.GetComponent<PlayerHit>().HitPlayer(this.transform.position, 30, 1, 40, false);
            }
            else
            {
                bossAnim.StunBoss();
                other.GetComponent<PlayerHealth>().HealPlayer(other.GetComponent<PlayerManager>().parryHealingAmmount);



            }

        }
    }


}
