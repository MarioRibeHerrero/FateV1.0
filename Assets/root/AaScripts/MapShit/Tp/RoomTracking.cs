using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RoomTracking : MonoBehaviour
{
    [SerializeField] bool usingTp;
    [SerializeField] bool toBridge;

    [Header("Using colliders")]
    [SerializeField] GameManager.Rooms previusRoom, nextRoom;



    [Header("Using TP")]

    [SerializeField] Transform previusRoomPos, nextRoomPos;
    [SerializeField] GameObject text;


    private CameraManager camManager;
    private GameObject player;


    private void Awake()
    {
        camManager = GameObject.FindAnyObjectByType<CameraManager>();
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            player = other.gameObject;
            if (usingTp)
            {
                text.SetActive(true);
                PlayerInteract.onInteract += UsingTp;
            }
            else UsingColliders();
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (usingTp) text.SetActive(false);
        PlayerInteract.onInteract -= UsingTp;

    }



    private void UsingColliders()
    {
        //ENTER
        if (GameManager.Instance.currentRoom == previusRoom)
        {
            if(toBridge) GameManager.Instance.inBridge = true;
            else Invoke(nameof(InBridgeToFalse), 3f);


            

            GameManager.Instance.currentRoom = nextRoom;
            camManager.SetNewCamera(nextRoom);
            camManager.DisableOldCamera(previusRoom);

            return;
        }
        //Exit
        if (GameManager.Instance.currentRoom == nextRoom)
        {
            if (toBridge) Invoke(nameof(InBridgeToFalse), 3f);

            GameManager.Instance.currentRoom = previusRoom;
            camManager.SetNewCamera(previusRoom);
            camManager.DisableOldCamera(nextRoom);
            return;
        }
    }
    private void UsingTp()
    {
        //ENTER
        if (GameManager.Instance.currentRoom == previusRoom)
        {
            if (toBridge) GameManager.Instance.inBridge = true;
            else Invoke(nameof(InBridgeToFalse), 3f);


            GameManager.Instance.currentRoom = nextRoom;
            camManager.SetNewCamera(nextRoom);
            camManager.DisableOldCamera(previusRoom);

            player.transform.position = nextRoomPos.position;


            return;
            Debug.Log("TP");

        }

        //Exit
        if (GameManager.Instance.currentRoom == nextRoom)
        {
            if (toBridge) Invoke(nameof(InBridgeToFalse), 3f);

            GameManager.Instance.currentRoom = previusRoom;
            camManager.SetNewCamera(previusRoom);
            camManager.DisableOldCamera(nextRoom);

            player.transform.position = previusRoomPos.position;

            return;
        }

        PlayerInteract.onInteract -= UsingTp;

    }



    private void InBridgeToFalse()
    {
        if (toBridge) GameManager.Instance.inBridge = false;
    }
}
