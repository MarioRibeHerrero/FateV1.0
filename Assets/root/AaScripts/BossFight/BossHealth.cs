using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class BossHealth : MonoBehaviour
{
    private GameObject player;
    PlayerManager pManager;

    

    BossFightController bFController;


    [Header("BossHealth")]
    [SerializeField] int hitsFirstFace, totalHits;

    [Header("BossHit")]
    [SerializeField] float hitTime;


    private int playerHit;


    //END OF BOSSFIGHT
    [Header("FIN BOSS")]

    [SerializeField] GameObject credits, instantTp, challangeTp;
    [SerializeField] GameObject room1_6, room1_6_1;

    private void Awake()
    {
        player = GameObject.FindObjectOfType<PlayerInput>().gameObject;
        pManager = player.GetComponent<PlayerManager>();
        bFController = GetComponent<BossFightController>();
    }




    public void SetHealth()
    {
        playerHit = pManager.playerCurrentDamage;

        
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
            bFController.EndBossFight();
        }
        
    }

    public void EndFight()
    {
        Invoke("LoadCredits", 9f);
    }

    private void LoadCredits()
    {
        this.transform.Find("Boss").gameObject.SetActive(false);

        credits.SetActive(true);
        instantTp.SetActive(true);
        challangeTp.SetActive(false);
        //OAODSJLASJDOJAN
        room1_6.SetActive(false);
        room1_6_1.SetActive(true);
    }
}
