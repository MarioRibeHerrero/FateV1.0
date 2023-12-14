using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeEntryExit : MonoBehaviour
{

    [SerializeField] CinemachineVirtualCamera cam;
    [SerializeField] GameObject player;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            cam.Priority = 100;

            PlayerIntoBridgeMode();

        }


    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            cam.Priority = 0;
            PlayerOutOffBridgeMode();
        }
            
            

    }

    private void PlayerIntoBridgeMode()
    {
        GameManager.Instance.inBridge = true;
        player.GetComponent<PlayerJump>().enabled = false;
        //CantAA

        GameManager.Instance.isOccupied = true;
        GameManager.Instance.isPlayerParry = true;

    }

    private void PlayerOutOffBridgeMode()
    {
        GameManager.Instance.inBridge = false;

        player.GetComponent<PlayerJump>().enabled = true;
        //CantAA
        GameManager.Instance.isOccupied = false;
        GameManager.Instance.isPlayerParry = false;




    }

}
