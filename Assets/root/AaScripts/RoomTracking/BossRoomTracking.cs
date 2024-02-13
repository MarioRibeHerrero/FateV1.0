using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BossRoomTracking : MonoBehaviour
{

    #region Vars
    [Header("Using colliders")]
    [SerializeField] GameManager.Rooms previusRoom, nextRoom;

    private CameraManager camManager;
    private GameObject player;

    [SerializeField] GameObject text;
    [SerializeField] Transform prevPos, nextPos;


    [SerializeField] BossFightController bFight;

    #endregion
    private void Awake()
    {
        camManager = GameObject.FindAnyObjectByType<CameraManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        player = other.gameObject;

            if (other.CompareTag("Player"))
            {


                text.SetActive(true);
                PlayerInteract.onInteract += ApplyFade;

            }
        


    }




    private void OnTriggerExit(Collider other)
    {


            if (other.CompareTag("Player"))
            {
                text.SetActive(false);
                PlayerInteract.onInteract -= ApplyFade;

            }
        

    }


    private void UsingTp()
    {
        if (GameManager.Instance.currentRoom == previusRoom)
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
        AudioManager.Instance.PlayOpenBossDoor();
        player.GetComponent<PlayerInput>().SwitchCurrentActionMap("Dead");
        UiManager.FadeIn();
        Invoke(nameof(UsingTp), 0.30f);
        Invoke(nameof(NormalActionMap), 1.5f);
    }

    private void NormalActionMap()
    {
        player.GetComponent<PlayerInput>().SwitchCurrentActionMap("PlayerNormalMovement");
        StartBossFight();
    }

    private void StartBossFight()
    {
        bFight.StartBossFight();
        
    }
}