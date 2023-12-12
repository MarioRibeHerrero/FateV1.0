using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathColliders : MonoBehaviour
{
    private PlayerHit playerHit;

    private void Awake()
    {
        playerHit = GameObject.FindAnyObjectByType<PlayerHit>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerHit.HitPlayer(this.transform.position,0, 0, 1000, false);
        }
    }
}
