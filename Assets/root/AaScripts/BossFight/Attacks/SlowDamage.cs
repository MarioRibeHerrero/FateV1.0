using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDamage : MonoBehaviour
{
    [SerializeField] int damage;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject.FindObjectOfType<PlayerHit>().HitPlayer(this.transform.position, 0, 0, damage, true);
        }
    }
}
