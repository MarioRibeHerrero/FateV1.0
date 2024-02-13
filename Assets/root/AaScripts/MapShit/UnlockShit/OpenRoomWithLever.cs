using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenRoomWithLever : MonoBehaviour
{
    [SerializeField] Animator doorAnimator;
    [SerializeField] GameObject exitCamera;

    
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
        exitCamera.SetActive(true);
        GetComponent<Animator>().SetTrigger("TurnOn");
        OpenDoor();
    }

    private void OpenDoor()
    {

        AudioManager.Instance.PlayOpenLock();
        Invoke(nameof(OpenDoorD), 0.75f);
    }


    private void OpenDoorD()
    {
        AudioManager.Instance.PlayOpenMetalDoor();

        doorAnimator.SetTrigger("OpenSlow");
        Invoke(nameof(DisableCam), 0.5f);
    }
    private void DisableCam()
    {
        exitCamera.SetActive(false);
    }
}
