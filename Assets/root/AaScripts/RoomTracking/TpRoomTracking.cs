using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TpRoomTracking : MonoBehaviour
{

    #region Vars
    [Header("Using colliders")]
    [SerializeField] GameManager.Rooms previusRoom, nextRoom;

    private CameraManager camManager;
    private GameObject player;

    [SerializeField] GameObject text;
    [SerializeField] Transform prevPos, nextPos;

    [SerializeField] bool instant;


    public Event startBossfight;
    #endregion
    private void Awake()
    {
        camManager = GameObject.FindAnyObjectByType<CameraManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        player = other.gameObject;
        if (instant)
        {
            UsingTp();
        }
        else
        {
            if (other.CompareTag("Player"))
            {
                

                text.SetActive(true);
                PlayerInteract.onInteract += UsingTp;

            }
        }


    }




    private void OnTriggerExit(Collider other)
    {
        if (instant)
        {

        }
        else
        {

            if (other.CompareTag("Player"))
            {
                text.SetActive(false);
                PlayerInteract.onInteract -= UsingTp;

            }
        }

    }
    

    private void UsingTp()
    {

        if(GameManager.Instance.currentRoom == previusRoom)
        {
            GameManager.Instance.currentRoom = nextRoom;
            camManager.SetNewCamera(nextRoom);
            camManager.DisableOldCamera(previusRoom);
            player.transform.position = nextPos.position;
            return;
        }


        if (GameManager.Instance.currentRoom == nextRoom)
        {
            GameManager.Instance.currentRoom = previusRoom;
            camManager.SetNewCamera(previusRoom);
            camManager.DisableOldCamera(nextRoom);
            player.transform.position = prevPos.position;
            return;

        }
    }
}
