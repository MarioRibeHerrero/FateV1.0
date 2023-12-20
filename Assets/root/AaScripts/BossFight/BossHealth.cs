using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossHealth : MonoBehaviour
{
    [SerializeField] BossFightController bFController;


    [Header("BossHealth")]
    [SerializeField] int hitsFirstFace, totalHits;

    [Header("BossHit")]
    [SerializeField] float hitTime;


    private int playerHit;
    




    void Start()
    {

        playerHit = GameManager.Instance.playerDamage;



        bFController.bossTotalHealth = totalHits * playerHit;
        bFController.bossCurrentHealth = bFController.bossTotalHealth;



    }


    public void Reset()
    {
        GetComponent<BossSpikeAttack>().Reset();
        GetComponent<BossFrisbiAttack>().Reset();
        GetComponent<BossUiManager>().DisableHealth();
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
            SceneManager.LoadScene(0);
            //Kill
            Destroy(gameObject);

        }
    }
}
