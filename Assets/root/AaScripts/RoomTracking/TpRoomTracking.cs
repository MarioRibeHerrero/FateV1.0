using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class TpRoomTracking : MonoBehaviour
{

    #region Vars
    [Header("Using colliders")]
    [SerializeField] GameManager.Rooms previusRoom, nextRoom;

    private CameraManager camManager;
    private GameObject player;

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
        if(other.CompareTag("Player")) player = other.gameObject;

        if (instant)
        {
            ApplyFade();
        }
        else
        {
            if (other.CompareTag("Player"))
            {
                

                PlayerInteract.onInteract += ApplyFade;

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
                PlayerInteract.onInteract -= ApplyFade;

            }
        }

    }
    

    private void UsingTp()
    {

        SaveSystem.SaveGameManager(GameManager.Instance);

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


    private void ApplyFade()
    {
        AudioManager.Instance.PlayPlayerStairs();
        player.GetComponent<PlayerInput>().SwitchCurrentActionMap("Dead");
        UiManager.FadeIn();
        Invoke(nameof(UsingTp), 0.30f);
        Invoke(nameof(NormalActionMap), 1.5f);
    }


    private void NormalActionMap()
    {
        player.GetComponent<PlayerInput>().SwitchCurrentActionMap("PlayerNormalMovement");

    }
}
