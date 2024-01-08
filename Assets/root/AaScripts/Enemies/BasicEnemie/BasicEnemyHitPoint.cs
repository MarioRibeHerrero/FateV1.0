using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

public class BasicEnemyHitPoint : MonoBehaviour
{
    [SerializeField] GameObject  root;

    private enum Points
    {
        head,
        body,
        weapon
    }
    [SerializeField] private Points whatPointAmI;

    private PlayerHealth phealth;
    private PlayerManager pManager;
    private void Awake()
    {
        phealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        pManager = phealth.transform.GetComponent<PlayerManager>();
    }

    private void HealPlayer()
    {
        phealth.HealPlayer(pManager.parryHealingAmmount);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(this.name + other.name);






        switch (whatPointAmI)
        {
            case Points.head:

                if (other.CompareTag("Player"))
                {
                    root.GetComponent<BasicEnemyAttack>().HitHead(other);

                }
                break;



            case Points.body:



                if (other.CompareTag("Player"))
                {
                    if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerGroundCheck>().isPlayerGrounded)
                    {
                        root.GetComponent<BasicEnemyAttack>().HitBody(other);
                    }
                    else root.GetComponent<BasicEnemyAttack>().HitHead(other);
                }

                break;

            case Points.weapon:

                if (other.CompareTag("Parry"))
                {
                    root.GetComponent<Animator>().SetTrigger("Stunned");
                    HealPlayer();
                    return;
                }

                if (other.CompareTag("Player"))
                {
                    if(root.GetComponent<MeleeEnemyState>().state != MeleeEnemyState.MeleeEnemyStateEnum.Stunned)
                    {
                        root.GetComponent<BasicEnemyAttack>().BasicAttack(other);
                    }
                }

                break;





        }





    }
}
