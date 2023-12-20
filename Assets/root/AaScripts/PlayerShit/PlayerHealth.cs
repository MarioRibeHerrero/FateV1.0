using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] CameraManager camManager;

    [SerializeField] UiManager uiManager;
    public Transform currentSpawnPoint;


    private RoundEnrtyCollider entryCollider;
    private RoundManager roundManager;


    

    private void Awake()
    {
        roundManager = GameObject.FindAnyObjectByType<RoundManager>();
        entryCollider = GameObject.FindAnyObjectByType<RoundEnrtyCollider>().GetComponent<RoundEnrtyCollider>();

    }

    void Start()
    {
        GameManager.Instance.isPlayerAlive = true;

    }


    public void TakeDamage(float damage)
    {
        GameManager.Instance.playerHealth -= damage;
        CheckHealth();
        uiManager.UpdatePlayerHealthSlider();
    }

    public void HealPlayer(float healAmmount)
    {
        GameManager.Instance.playerHealth += healAmmount;
        CheckHealth();
        uiManager.UpdatePlayerHealthSlider();
    }
    private void CheckHealth()
    {

        if (GameManager.Instance.playerHealth >= 100) GameManager.Instance.playerHealth = 100f;
        if (GameManager.Instance.playerHealth <= 0)
        {

            if (roundManager.inRoundRoom)
            {

                //ResetearLaRoom
                roundManager.inRoundRoom = false;
                entryCollider.gameObject.transform.parent.GetComponent<Animator>().SetTrigger("OpenDoors");
                entryCollider.doorsColsed = false;

                ResetEnemies();
                ResetCristal();

                //-----------------
            }

            GameManager.Instance.isPlayerAlive = false;
            DesactivateAllPlayerFuntionsAndKill();
            StartCoroutine(RevivePlayer());

        }
    }


    private void ResetCristal()
    {
        if(!roundManager.isCristalDestroyed)
        {
            roundManager.cristal.SetActive(false);
            roundManager.cristal.GetComponent<RoundCristal>().Reset();
        }
    }
    private void ResetEnemies()
    {
        //instantiate and desactivar enemies
        if (roundManager != null && roundManager.roundRoomEnemies != null)
        {
            if (roundManager.roundRoomEnemies.Count == 0) return;

            foreach (GameObject enemy in roundManager.roundRoomEnemies.ToList())
            {
                // Check if the enemy object is not null
                if (enemy != null)
                {
                    BasicEnemyHealth basicEnemyHealth = enemy.GetComponent<BasicEnemyHealth>();

                    // Check and apply damage to BasicEnemyHealth
                    if (basicEnemyHealth != null)
                    {
                        basicEnemyHealth.TakeDamage(1000);
                    }

                }
            }
        }




    }



    



    private void DesactivateAllPlayerFuntionsAndKill()
    {
        transform.Find("Body").transform.gameObject.SetActive(false);

        GetComponent<PlayerMovement>().enabled = false;
        GetComponent<PlayerRotation>().enabled = false;
        GetComponent<PlayerJump>().enabled = false;
        GetComponent<PlayerParry>().enabled = false;
        GetComponent<PlayerAa>().enabled = false;
        GetComponent<PlayerHook>().enabled = false;

    }


    private void ActivateAllPlayerFuntionsAndKill()
    {

        GetComponent<PlayerMovement>().enabled = true;
        GetComponent<PlayerRotation>().enabled = true;
        GetComponent<PlayerJump>().enabled = true;
        GetComponent<PlayerParry>().enabled = true;
        GetComponent<PlayerAa>().enabled = true;
        GetComponent<PlayerHook>().enabled = true;

    }

    private IEnumerator RevivePlayer()
    {
        SetCameraToRespawnCamera();
        yield return new WaitForSeconds(1);
        transform.position = currentSpawnPoint.transform.position;
        transform.Find("Body").transform.gameObject.SetActive(true);
        ActivateAllPlayerFuntionsAndKill();
        GameManager.Instance.playerHealth = 100f;
        uiManager.UpdatePlayerHealthSlider();
        GameManager.Instance.isPlayerAlive = true;
        //camFollow.ZoomIn();
        GameManager.Instance.isZoomed = false;

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Death"))
        {
            TakeDamage(100);
        }
    }





    private void SetCameraToRespawnCamera()
    {
        camManager.DisableOldCamera(GameManager.Instance.currentRoom);
        camManager.SetNewCamera(GameManager.Instance.RespawnRoom);
        
        GameManager.Instance.currentRoom = GameManager.Instance.RespawnRoom;

    }

}
