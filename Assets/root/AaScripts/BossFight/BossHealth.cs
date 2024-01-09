using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class BossHealth : MonoBehaviour
{
    private GameObject player;
    PlayerManager pManager;



    [SerializeField] BossFightController bFController;


    [Header("BossHealth")]
    [SerializeField] int hitsFirstFace, totalHits;

    [Header("BossHit")]
    [SerializeField] float hitTime;


    private int playerHit;


    private void Awake()
    {
        player = GameObject.FindObjectOfType<PlayerInput>().gameObject;
        pManager = player.GetComponent<PlayerManager>();
    }


    void Start()
    {

        playerHit = pManager.playerCurrentDamage;

        Debug.Log(playerHit);

        bFController.bossTotalHealth = totalHits * playerHit;
        bFController.bossCurrentHealth = bFController.bossTotalHealth;



    }




    public void CheckHealth()
    {
        if(bFController.bossCurrentHealth <= hitsFirstFace * playerHit)
        {
            //Enter second faece
            bFController.inSecondFace = true;

        }
        if (bFController.bossCurrentHealth <= 0)
        {
            
            //Kill
            gameObject.SetActive(false);
            Invoke("LoadCredits", 3f);
        }
    }



    private void LoadCredits()
    {
        SceneManager.LoadScene(2);
    }
}
