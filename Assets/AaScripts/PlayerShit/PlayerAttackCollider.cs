using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackCollider : MonoBehaviour
{
    [SerializeField] int damageDealt;
    [SerializeField] int healthHealed;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            
            other.transform.parent.GetComponent<GenericHealth>().TakeDamage(damageDealt);

            


            //si la vida es mas de 100, no le sumes nada
            transform.root.GetComponent<PlayerHealth>().HealPlayer(healthHealed);
            if(GameManager.Instance.playerHealth >= 100)
            {
                GameManager.Instance.playerHealth = 100;
            }
         //   GameObject.FindAnyObjectByType<UiManager>().UpdatePlayerHealthSlider();
        }

        if (other.CompareTag("Cristal"))
        {

            other.transform.GetComponent<CristalHealthManager>().TakeDamage(damageDealt);

        }
    }
}
