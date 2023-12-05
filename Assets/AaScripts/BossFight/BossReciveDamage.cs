using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class BossReciveDamage : MonoBehaviour, IDamageable
{

    [SerializeField] GameObject rootBoss;
    private BossHealth bossHealth;
    private BossFightController bossFController;
    private void Awake()
    {
        bossHealth = rootBoss.GetComponent<BossHealth>();
        bossFController = rootBoss.GetComponent<BossFightController>();

    }


    public void TakeDamage(int damageTaken)
    {
        bossFController.bossTotalHealth -= damageTaken;
        StartCoroutine(HitVisualEffect(bossFController.hitTime));

        bossHealth.CheckHealth();
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
}
