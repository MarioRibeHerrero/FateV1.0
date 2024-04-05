using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushDamage : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject.FindObjectOfType<PlayerHit>().HitPlayer(this.transform.position, 20, 1, 30, false);
        }
    }
}
