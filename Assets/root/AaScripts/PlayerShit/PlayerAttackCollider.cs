using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackCollider : MonoBehaviour
{
    [SerializeField] int healthHealed;
    [SerializeField] PlayerAa aaCombo;
    PlayerManager pManager;
    PlayerAnimationManager pAnim;


    private void Awake()
    {
        pManager = aaCombo.transform.GetComponent<PlayerManager>();
        pAnim = aaCombo.transform.GetComponent<PlayerAnimationManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        //TakeDamage
        var damageable = other.GetComponent<IDamageable>();
        if (damageable == null) return;
        damageable.TakeDamage(pManager.playerCurrentDamage);
        if(aaCombo.goToSecondAaCheck) { pAnim.SetHitEnemy(); }
        //Heal
        var healPlayer = other.GetComponent<IHealPlayer>();
        if (healPlayer == null) return;
        //Heal for the aa healing ammount;
        aaCombo.transform.GetComponent<PlayerHealth>().HealPlayer(pManager.aaHealingAmmount);
        
    }
}
