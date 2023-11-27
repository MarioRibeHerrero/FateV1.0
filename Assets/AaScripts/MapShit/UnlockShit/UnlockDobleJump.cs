using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockDobleJump : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.isDobleJumpUnlocked = true;
        }
    }
}
