using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.VFX;

public class PlayerHealth : MonoBehaviour
{

    #region Vars

    PlayerManager pManager;
    PlayerInput pInput;

    public delegate void OnPlayerDeath();
    public OnPlayerDeath onPlayerDeath;

    [SerializeField] CameraManager camManager;
    [SerializeField] UiManager uiManager;

    public Transform currentSpawnPoint;

    [SerializeField] VisualEffect parry;

    #endregion


    private void Awake()
    {
        if (currentSpawnPoint != null) SetPlayerToStartPos();
       // else Debug.LogWarning("te falta el respawnPoint");

        pManager = GetComponent<PlayerManager>();
        pInput = GetComponent<PlayerInput>();
    }


    public void TakeDamage(float damage)
    {
        pManager.playerHealth -= damage;
        CheckHealth();
        uiManager.UpdatePlayerHealthSlider();
    }
    public void HealParryPlayer(float healAmmount)
    {
        parry.Play();
        pManager.playerHealth += healAmmount;
        CheckHealth();
        uiManager.UpdatePlayerHealthSlider();
    }
    public void HealPlayer(float healAmmount)
    {
        pManager.playerHealth += healAmmount;
        CheckHealth();
        uiManager.UpdatePlayerHealthSlider();
    }
    private void CheckHealth()
    {

        if (pManager.playerHealth >= 100) pManager.playerHealth = 100f;
        if (pManager.playerHealth <= 0)
        {
            if(onPlayerDeath != null) onPlayerDeath();
            pManager.isPlayerAlive = false;
            DesactivateAllPlayerFuntionsAndKill();
            StartCoroutine(RevivePlayer());

        }
    }




    



    private void DesactivateAllPlayerFuntionsAndKill()
    {
        transform.Find("Body").transform.gameObject.SetActive(false);

        pInput.SwitchCurrentActionMap("Dead");
        GetComponent<PlayerGravity>().StopPlayerMoving();
        AudioManager.Instance.PlayPlayerDeath();

    }

    private void ActivateAllPlayerFuntionsAndKill()
    {

        pInput.SwitchCurrentActionMap("PlayerNormalMovement");


    }

    private IEnumerator RevivePlayer()
    {
        SetCameraToRespawnCamera();
        yield return new WaitForSeconds(0.75f);
        UiManager.FadeIn();
        yield return new WaitForSeconds(0.25f);

        GetComponent<PlayerGravity>().ReturnPlayerMovement();

        transform.position =
            new Vector3(currentSpawnPoint.transform.position.x, currentSpawnPoint.transform.position.y, 0);
        transform.Find("Body").transform.gameObject.SetActive(true);
        ActivateAllPlayerFuntionsAndKill();
        pManager.playerHealth = 100f;
        uiManager.UpdatePlayerHealthSlider();
        pManager.isPlayerAlive = true;
        
        //music
        AudioManager.Instance.StopAllMusic();
        AudioManager.Instance.LevelTheme();

    }
    
    private void SetPlayerToStartPos()
    {
        SetCameraToRespawnCamera();
        transform.position = currentSpawnPoint.transform.position;
        transform.Find("Body").transform.gameObject.SetActive(true);
        ActivateAllPlayerFuntionsAndKill();
        pManager.playerHealth = 100f;
        uiManager.UpdatePlayerHealthSlider();
        pManager.isPlayerAlive = true;
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
