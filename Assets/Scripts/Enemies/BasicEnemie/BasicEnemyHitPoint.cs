using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class BasicEnemyHitPoint : MonoBehaviour
{

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

                        transform.parent.GetComponent<BasicEnemyAttack>().HitHead(other);

                    }
                    else
                    {
                        transform.root.GetComponent<Animator>().SetTrigger("Stunned");
                        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().HealPlayer(30);
                    }

                    break;

                
                
            case Points.body:


                    if (!GameManager.Instance.isPlayerParry)
                    {
                        
                        if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerGroundCheck>().isPlayerGrounded)
                        {
                            transform.parent.GetComponent<BasicEnemyAttack>().HitBody(other);
                        }else transform.parent.GetComponent<BasicEnemyAttack>().HitHead(other);
                    }
                    else
                    {
                        transform.root.GetComponent<Animator>().SetTrigger("Stunned");
                        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().HealPlayer(30);
                    }
                    
                
                break;

                case Points.weapon:


                    if (!GameManager.Instance.isPlayerParry)
                    {
                        transform.parent.GetComponent<BasicEnemyAttack>().BasicAttack(other);

                    }
                    else
                    {
                        transform.root.GetComponent<Animator>().SetTrigger("Stunned");
                        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().HealPlayer(30);
                    }


                    
               
                break;
            }
        }






    }
}
