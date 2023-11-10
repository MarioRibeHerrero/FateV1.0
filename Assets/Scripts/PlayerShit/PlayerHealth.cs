using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] UiManager uiManager;
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
            uiManager.UpdatePlayerHealthSlider();
        }
    }
}
