using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenRoomWithLever : MonoBehaviour
{
    [SerializeField] Animator doorAnimator;


    
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            PlayerInteract.onInteract += UnlockDoor;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInteract.onInteract -= UnlockDoor;

        }
    }


    private void UnlockDoor()
    {
        GetComponent<Animator>().SetTrigger("TurnOn");
        doorAnimator.SetTrigger("OpenFast");
    }
}
