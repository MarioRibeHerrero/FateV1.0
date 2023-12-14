using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class BossReciveDamage : MonoBehaviour, IDamageable
{

    [SerializeField] GameObject rootBoss;
    private Animator packAnim;

    private BossHealth bossHealth;
    private BossFightController bossFController;
    private void Awake()
    {
        bossHealth = rootBoss.GetComponent<BossHealth>();
        bossFController = rootBoss.GetComponent<BossFightController>();
        packAnim = rootBoss.GetComponent<Animator>();

    }


    public void TakeDamage(int damageTaken)
    {
        bossFController.bossCurrentHealth -= damageTaken;
        packAnim.SetTrigger("Hit");

        bossHealth.CheckHealth();
    }


}
