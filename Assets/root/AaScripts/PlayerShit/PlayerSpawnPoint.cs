using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSpawnPoint : MonoBehaviour
{

    private GameObject spawnPoint;
    private GameObject lastSpawnPoint;


    //components
    PlayerHealth pHealth;
    PlayerRotation pRotation;
    PlayerInput playerInput;
    PlayerGroundCheck pGroundCheck;
    PlayerManager pManager;
    [SerializeField] Animator anim;

    //mats
    [SerializeField] Material currentM, defaultM;


    private void Awake()
    {
        //GettingComponents
        pHealth = GetComponent<PlayerHealth>();
        pRotation = GetComponent<PlayerRotation>();
        playerInput = GetComponent<PlayerInput>();
        pGroundCheck = GetComponent<PlayerGroundCheck>();
        pManager = GetComponent<PlayerManager>();
    }
    private void Start()
    {
        //vars
        spawnPoint = null;
        lastSpawnPoint = null;
    }
    private void SpawnPosShit()
    {

        pManager.playerSitting = true;


        if (!pGroundCheck.isPlayerGrounded) return;

        playerInput.SwitchCurrentActionMap("PopUps");

        LeanTween.moveLocalX(gameObject, spawnPoint.transform.position.x, 0.5f);


        if (pRotation.isFacingRight)
        {
            //

            anim.SetTrigger("SitLeft");

            AnimationClip[] clips = anim.runtimeAnimatorController.animationClips;
            foreach (AnimationClip clip in clips)
            {

                if (clip.name == "Fate_SitLeft")
                {
                    Invoke(nameof(SetSpawnPoint), clip.length);
                    break;

                }

            }

        }
        else
        {
            anim.SetTrigger("SitRight");

            AnimationClip[] clips = anim.runtimeAnimatorController.animationClips;

            foreach (AnimationClip clip in clips)
            {
                if (clip.name == "Fate_SitRight")
                {
                    Invoke(nameof(SetSpawnPoint), clip.length);
                    break;
                }
            }
        }



    }


    public void SetSpawnPoint()
    {
        Debug.Log("AKKAK");
        playerInput.SwitchCurrentActionMap("PlayerNormalMovement");

        if (spawnPoint != null)
        {
            if (spawnPoint != lastSpawnPoint && lastSpawnPoint != null)
            {
                lastSpawnPoint.GetComponent<MeshRenderer>().material = defaultM;
            }

            spawnPoint.GetComponent<MeshRenderer>().material = currentM;
            pHealth.currentSpawnPoint = spawnPoint.transform.GetChild(0);



            lastSpawnPoint = spawnPoint;
            SetNewCamOnRespawn();
            pHealth.HealPlayer(100);


            //SAVING SHIT
            GameManager.Instance.respawnVector = transform.position;

            SaveSystem.SaveGameManager(GameManager.Instance);

        }
    }
    private void SetNewCamOnRespawn()
    {
        GameManager.Instance.RespawnRoom = GameManager.Instance.currentRoom;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SpawnPoint"))
        {
            spawnPoint = other.gameObject;
            PlayerInteract.onInteract += SpawnPosShit;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("SpawnPoint"))
        {
            spawnPoint = null;
            PlayerInteract.onInteract -= SpawnPosShit;

        }
    }

}
