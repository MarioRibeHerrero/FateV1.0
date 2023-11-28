using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackCollider : MonoBehaviour
{
    [SerializeField] int damageDealt;
    [SerializeField] int healthHealed;

    private void Start()
    {
        GameManager.Instance.playerDamage = damageDealt;
    }
    private void OnTriggerEnter(Collider other)
    {
        //TakeDamage
        var damageable = other.GetComponent<IDamageable<int>>();
        if (damageable == null) return;
        damageable.TakeDamage(GameManager.Instance.playerDamage);

        //Heal
        var healPlayer = other.GetComponent<IHealPlayer<int>>();
        if (healPlayer == null) return;
        healPlayer.HealPlayer(healthHealed);
    }
}
