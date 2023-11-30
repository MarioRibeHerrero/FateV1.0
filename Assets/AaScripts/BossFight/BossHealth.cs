using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour, IDamageable
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




    public void TakeDamage(int damageTaken)
    {
        bFController.bossTotalHealth -= damageTaken;
        StartCoroutine(HitVisualEffect(hitTime));

        CheckHealth();
    }

    private IEnumerator HitVisualEffect(float hitTime)
    {
        //Aply shader to model(de momento color pocho


       // Material currentMat = GetComponent<MeshRenderer>().material;
        Color color = GetComponent<MeshRenderer>().material.color;

        GetComponent<MeshRenderer>().material.color = Color.white;
        yield return new WaitForSeconds(hitTime);
        GetComponent<MeshRenderer>().material.color = color;

    }
    private void CheckHealth()
    {
        if (bFController.bossTotalHealth <= 0)
        {
            doorAnimator.SetTrigger("Open");

            //Kill
            Destroy(gameObject);
        }
    }
}
