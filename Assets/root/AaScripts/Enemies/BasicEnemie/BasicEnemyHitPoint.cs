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



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            switch (whatPointAmI)
            {
            case Points.head:

                    if (!GameManager.Instance.isPlayerParry)
                    {

                        root.GetComponent<BasicEnemyAttack>().HitHead(other);

                    }
                    else
                    {
                        root.GetComponent<Animator>().SetTrigger("Stunned");
                        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().HealPlayer(15);
                    }

                    break;

                
                
            case Points.body:


                    if (!GameManager.Instance.isPlayerParry)
                    {
                        
                        if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerGroundCheck>().isPlayerGrounded)
                        {
                            root.GetComponent<BasicEnemyAttack>().HitBody(other);
                        }else root.GetComponent<BasicEnemyAttack>().HitHead(other);
                    }
                    else
                    {
                        root.GetComponent<Animator>().SetTrigger("Stunned");
                        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().HealPlayer(30);
                    }
                    
                
                break;

                case Points.weapon:


                    if (!GameManager.Instance.isPlayerParry)
                    {
                        root.GetComponent<BasicEnemyAttack>().BasicAttack(other);

                    }
                    else
                    {
                        root.GetComponent<Animator>().SetTrigger("Stunned");
                        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().HealPlayer(30);
                    }


                    
               
                break;
            }
        }






    }
}