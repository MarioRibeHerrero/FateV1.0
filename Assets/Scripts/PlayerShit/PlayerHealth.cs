using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] UiManager uiManager;
    [SerializeField] Transform currentSpawnPoint;
    [SerializeField] GameObject player;




   
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


    private void CheckHealth()
    {
        if(GameManager.Instance.playerHealth <= 0)
        {
            player.SetActive(false);
            GameManager.Instance.isPlayerAlive = false;
            StartCoroutine(RevivePlayer());
            uiManager.UpdatePlayerHealthSlider();
        }
    }


    private IEnumerator RevivePlayer()
    {
        yield return new WaitForSeconds(1);
        player.transform.position = currentSpawnPoint.transform.position;
        player.SetActive(true);

    }

}
