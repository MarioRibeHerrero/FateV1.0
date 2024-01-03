using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockDobleJump : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerManager>().isDobleJumpUnlocked = true;
        }
    }
}
