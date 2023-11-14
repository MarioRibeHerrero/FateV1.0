using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] UiManager uiManager;
    public Transform currentSpawnPoint;
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
           
            GameManager.Instance.isPlayerAlive = false;
            StartCoroutine(RevivePlayer());
            GameManager.Instance.playerHealth = 100f;
            uiManager.UpdatePlayerHealthSlider();
        }
    }


    private IEnumerator RevivePlayer()
    {
        yield return new WaitForSeconds(1);
        transform.position = currentSpawnPoint.transform.position;
        

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Death"))
        {
            TakeDamage(100);
        }
    }

}
