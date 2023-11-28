using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour, IDamageable
{
    [Header("BossHealth")]
    [SerializeField] int hitsFirstFace, totalHits;

    [Header("BossHit")]
    [SerializeField] float hitTime;




    private int bossTotalHealth;
    void Start()
    {
        bossTotalHealth = totalHits * GameManager.Instance.playerDamage;
    }




    public void TakeDamage(int damageTaken)
    {
        bossTotalHealth -= damageTaken;
        HitVisualEffect(hitTime);
        CheckHealth();
    }

    private IEnumerator HitVisualEffect(float hitTime)
    {
        //Aply shader to model(de momento color pocho


        Material currentMat = GetComponent<MeshRenderer>().material;
        GetComponent<MeshRenderer>().material.color = Color.white;
        yield return new WaitForSeconds(hitTime);
        GetComponent<MeshRenderer>().material = currentMat;

    }
    private void CheckHealth()
    {
        if (bossTotalHealth >= 0)
        {
            //Kill
            Destroy(gameObject);
        }
    }
}
