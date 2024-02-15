using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundEnrtyCollider : MonoBehaviour
{
    private RoundManager roundManager;

    private void Awake()
    {
        roundManager = GameObject.FindAnyObjectByType<RoundManager>();

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("RoundRoom");

        if (other.CompareTag("Player") && !roundManager.areDoorsClosed && !GameManager.Instance.roundRoomCompleted)
        {
            Invoke(nameof(CloseDoors), 0f);
        }
    }

    private void CloseDoors()
    {
        AudioManager.Instance.PlayOpenLock();
        roundManager.StartRoundRoom();
    }
}
