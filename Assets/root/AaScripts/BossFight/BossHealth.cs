using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    [SerializeField] BossFightController bFController;


    [Header("BossHealth")]
    [SerializeField] int hitsFirstFace, totalHits;

    [Header("BossHit")]
    [SerializeField] float hitTime;


    private int bossHp;

   
    
    void Start()
    {

        bossHp = GameManager.Instance.playerDamage;



        bFController.bossTotalHealth = totalHits * bossHp;
        bFController.bossCurrentHealth = bFController.bossTotalHealth;



    }





    public void CheckHealth()
    {
        if (bFController.bossCurrentHealth <= 0)
        {

            //Kill
            Destroy(gameObject);
        }
    }
}
