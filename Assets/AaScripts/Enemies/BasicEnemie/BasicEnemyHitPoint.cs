using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

public class BasicEnemyHitPoint : MonoBehaviour
{
    [SerializeField] GameObject parent, root;
    private enum Points
    {
        head,
        body,
        weapon
    }
    [SerializeField] private Points whatPointAmI;

    private Vector3 originalTransform;

    private void Start()
    {
       // this.transform.position = originalTransform;
    }

    private void OnEnable()
    {
        RoundManager.onResetRoundRoom += ResetWeaponPosition;
    }
    private void OnDisable()
    {
        RoundManager.onResetRoundRoom -= ResetWeaponPosition;
    }

    private void ResetWeaponPosition()
    {
     //   this.transform.position = originalTransform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            switch (whatPointAmI)
            {
            case Points.head:

                    if (!GameManager.Instance.isPlayerParry)
                    {

                        parent.GetComponent<BasicEnemyAttack>().HitHead(other);

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
                            parent.GetComponent<BasicEnemyAttack>().HitBody(other);
                        }else transform.parent.GetComponent<BasicEnemyAttack>().HitHead(other);
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
                        parent.GetComponent<BasicEnemyAttack>().BasicAttack(other);

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
