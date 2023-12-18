using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTracking : MonoBehaviour
{
    [SerializeField] bool usingTp;

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
        if (GameManager.Instance.currentRoom == previusRoom)
        {
            GameManager.Instance.currentRoom = nextRoom;
            camManager.SetNewCamera(nextRoom);
            camManager.DisableOldCamera(previusRoom);

            return;
        }

        if (GameManager.Instance.currentRoom == nextRoom)
        {
            GameManager.Instance.currentRoom = previusRoom;
            camManager.SetNewCamera(previusRoom);
            camManager.DisableOldCamera(nextRoom);
            return;
        }
    }
    private void UsingTp(Collider other)
    {

        if (GameManager.Instance.currentRoom == previusRoom)
        {
            GameManager.Instance.currentRoom = nextRoom;
            camManager.SetNewCamera(nextRoom);
            camManager.DisableOldCamera(previusRoom);

            other.transform.position = nextRoomPos.position;


            return;
        }

        if (GameManager.Instance.currentRoom == nextRoom)
        {
            GameManager.Instance.currentRoom = previusRoom;
            camManager.SetNewCamera(previusRoom);
            camManager.DisableOldCamera(nextRoom);

            other.transform.position = previusRoomPos.position;

            return;
        }
    }

}
