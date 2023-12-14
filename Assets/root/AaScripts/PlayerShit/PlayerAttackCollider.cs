using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackCollider : MonoBehaviour
{
    [SerializeField] int healthHealed;
    [SerializeField] PlayerAa aaCombo;
  

    private void OnTriggerEnter(Collider other)
    {
        //TakeDamage
        var damageable = other.GetComponent<IDamageable>();
        if (damageable == null) return;
        damageable.TakeDamage(GameManager.Instance.playerDamage);
        aaCombo.AddToCombo();
        //Heal
        var healPlayer = other.GetComponent<IHealPlayer>();
        if (healPlayer == null) return;
        GameManager.Instance.HealPlayer(healthHealed);
    }
}