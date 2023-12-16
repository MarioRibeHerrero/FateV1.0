using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTracking : MonoBehaviour
{
    [SerializeField] GameManager.Rooms previusRoom, nextRoom;

    private CameraManager camManager;


    private void Awake()
    {
        camManager = GameObject.FindAnyObjectByType<CameraManager>();
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
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

    }
    

}
