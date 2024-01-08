using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class RoomTracking : MonoBehaviour
{
    PlayerInput playerInput;


    [SerializeField] bool usingTp;
    [SerializeField] bool toThirdPerson;

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
        playerInput = GameObject.FindAnyObjectByType<PlayerInput>();
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
            if (toThirdPerson) SwitchToThirdPerson();
            else SwitchToNormal();


            

            GameManager.Instance.currentRoom = nextRoom;
            camManager.SetNewCamera(nextRoom);
            camManager.DisableOldCamera(previusRoom);

            return;
        }
        //Exit
        if (GameManager.Instance.currentRoom == nextRoom)
        {
            if (toThirdPerson) SwitchToNormal();

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
            if (toThirdPerson) SwitchToThirdPerson();
            else SwitchToNormal();


            GameManager.Instance.currentRoom = nextRoom;
            camManager.SetNewCamera(nextRoom);
            camManager.DisableOldCamera(previusRoom);

            player.transform.position = nextRoomPos.position;


            return;

        }

        //Exit
        if (GameManager.Instance.currentRoom == nextRoom)
        {
            if (toThirdPerson) SwitchToNormal();

            GameManager.Instance.currentRoom = previusRoom;
            camManager.SetNewCamera(previusRoom);
            camManager.DisableOldCamera(nextRoom);

            player.transform.position = previusRoomPos.position;

            return;
        }

        PlayerInteract.onInteract -= UsingTp;

    }




    private void SwitchToThirdPerson()
    {
        ActivateThirdPersonActionMap();
        GameManager.Instance.thirdPersonCam = true;
    }
    private void SwitchToNormal()
    {
        ActivateNormalActionMap();
        GameManager.Instance.thirdPersonCam = false;
    }
    private void ActivateThirdPersonActionMap()
    {
        playerInput.SwitchCurrentActionMap("ThirdPersonMovement");
    }
    private void ActivateNormalActionMap()
    {
        playerInput.SwitchCurrentActionMap("PlayerNormalMovement");
    }
}
