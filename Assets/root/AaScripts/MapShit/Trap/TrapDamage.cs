using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDamage : MonoBehaviour
{



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           GameObject.FindObjectOfType<PlayerHit>().HitPlayer(this.transform.position,0,0,30,true);
        }
    }


}

