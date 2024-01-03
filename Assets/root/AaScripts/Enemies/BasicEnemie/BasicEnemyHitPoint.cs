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
        if (other.CompareTag("Player"))
        {
            switch (whatPointAmI)
            {
            case Points.head:

                    if (!pManager.isPlayerParry)
                    {

                        root.GetComponent<BasicEnemyAttack>().HitHead(other);

                    }
                    else
                    {
                        root.GetComponent<Animator>().SetTrigger("Stunned");
                        HealPlayer();
                    }

                    break;

                
                
            case Points.body:


                    if (!pManager.isPlayerParry)
                    {
                        
                        if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerGroundCheck>().isPlayerGrounded)
                        {
                            root.GetComponent<BasicEnemyAttack>().HitBody(other);
                        }else root.GetComponent<BasicEnemyAttack>().HitHead(other);
                    }
                    else
                    {
                        root.GetComponent<Animator>().SetTrigger("Stunned");
                        HealPlayer();
                    }


                    break;

                case Points.weapon:


                    if (!pManager.isPlayerParry)
                    {
                        root.GetComponent<BasicEnemyAttack>().BasicAttack(other);

                    }
                    else
                    {
                        root.GetComponent<Animator>().SetTrigger("Stunned");
                        HealPlayer();
                    }




                    break;
            }
        }






    }
}
