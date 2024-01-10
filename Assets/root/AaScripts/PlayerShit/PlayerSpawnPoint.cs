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

    //mats
    [SerializeField] Material currentM, defaultM;


    private void Awake()
    {
        //GettingComponents
        pHealth = GetComponent<PlayerHealth>();
    }
    private void Start()
    {
        //vars
        spawnPoint = null;
        lastSpawnPoint = null;
    }
    private void SpawnPosShit()
    {
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
