using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSpawnPoint : MonoBehaviour
{

    private GameObject spawnPoint;
    private GameObject lastSpawnPoint;

    //InputActions
    PlayerInput playerInput;

    //components
    PlayerHealth pHealth;


    //mats
    [SerializeField] Material currentM, defaultM;

    private void Awake()
    {
        //InputActions
        playerInput = GetComponent<PlayerInput>();

        playerInput.actions["Hook"].started += PlayerSpawnPoint_started;
        //GettingComponents
        pHealth = GetComponent<PlayerHealth>();
    }
    private void Start()
    {




        //vars
        spawnPoint = null;
        lastSpawnPoint = null;


    }

    private void PlayerSpawnPoint_started(InputAction.CallbackContext obj)
    {
        if(spawnPoint != null)
        {
            if (spawnPoint  !=  lastSpawnPoint && lastSpawnPoint != null)
            {
                lastSpawnPoint.GetComponent<MeshRenderer>().material = defaultM;
            }

            spawnPoint.GetComponent<MeshRenderer>().material = currentM;
            pHealth.currentSpawnPoint = spawnPoint.transform.GetChild(0);



            lastSpawnPoint = spawnPoint;

        }        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SpawnPoint"))
        {
            spawnPoint = other.transform.parent.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("SpawnPoint"))
        {
            spawnPoint = null;
        }
    }

}
