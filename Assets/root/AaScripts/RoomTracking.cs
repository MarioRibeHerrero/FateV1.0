using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTracking : MonoBehaviour
{
    [SerializeField] bool usingTp;
    [SerializeField] bool toBridge;

    [Header("Using colliders")]
    [SerializeField] GameManager.Rooms previusRoom, nextRoom;



    [Header("Using TP")]

    [SerializeField] Transform previusRoomPos, nextRoomPos;


    private CameraManager camManager;


    private void Awake()
    {
        camManager = GameObject.FindAnyObjectByType<CameraManager>();
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            if (usingTp) UsingTp(other);
            else UsingColliders();
        }

    }
    



    private void UsingColliders()
    {
        Debug.Log("COLIDERS");
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
    private void UsingTp(Collider other)
    {
        Debug.Log("TP");
        //ENTER
        if (GameManager.Instance.currentRoom == previusRoom)
        {
            if (toBridge) GameManager.Instance.inBridge = true;
            else Invoke(nameof(InBridgeToFalse), 3f);


            GameManager.Instance.currentRoom = nextRoom;
            camManager.SetNewCamera(nextRoom);
            camManager.DisableOldCamera(previusRoom);

            other.transform.position = nextRoomPos.position;


            return;
        }

        //Exit
        if (GameManager.Instance.currentRoom == nextRoom)
        {
            if (toBridge) Invoke(nameof(InBridgeToFalse), 3f);

            GameManager.Instance.currentRoom = previusRoom;
            camManager.SetNewCamera(previusRoom);
            camManager.DisableOldCamera(nextRoom);

            other.transform.position = previusRoomPos.position;

            return;
        }
    }



    private void InBridgeToFalse()
    {
        if (toBridge) GameManager.Instance.inBridge = false;
    }
}
