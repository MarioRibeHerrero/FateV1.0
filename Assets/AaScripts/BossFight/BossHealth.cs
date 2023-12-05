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


    [SerializeField] Animator doorAnimator;


    private int bossHp;

   
    
    void Start()
    {

        bossHp = GameManager.Instance.playerDamage;



        bFController.bossTotalHealth = totalHits * bossHp;

       
    }





    public void CheckHealth()
    {
        if (bFController.bossTotalHealth <= 0)
        {
            doorAnimator.SetTrigger("Open");

            //Kill
            Destroy(gameObject);
        }
    }
}
