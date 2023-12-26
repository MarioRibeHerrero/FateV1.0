using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    #region Vars

    public delegate void OnPlayerDeath();
    public OnPlayerDeath onPlayerDeath;

    [SerializeField] CameraManager camManager;
    [SerializeField] UiManager uiManager;

    public Transform currentSpawnPoint;

    private RoundEnrtyCollider entryCollider;
    private RoundManager roundManager;

    #endregion


    private void Awake()
    {
        //Finding references
        roundManager = GameObject.FindAnyObjectByType<RoundManager>();
        entryCollider = GameObject.FindAnyObjectByType<RoundEnrtyCollider>().GetComponent<RoundEnrtyCollider>();
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
            if(onPlayerDeath != null) onPlayerDeath();
            GameManager.Instance.isPlayerAlive = false;
            DesactivateAllPlayerFuntionsAndKill();
            StartCoroutine(RevivePlayer());

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
