using Autodesk.Fbx;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SearchService;

public class BasicEnemyHitPoint : MonoBehaviour
{
    [SerializeField] GameObject  root;
    public bool isStunned;

    private MeleeEnemyStateController stateController;
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

        stateController = transform.parent.GetComponent<MeleeEnemyStateController>();
    }

    private void HealPlayer()
    {
        phealth.HealPlayer(pManager.parryHealingAmmount);
    }

    private void OnTriggerEnter(Collider other)
    {
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

                if (other.CompareTag("Player"))
                {

                    if (!other.GetComponent<PlayerManager>().isPlayerParry)
                    {
                        root.GetComponent<BasicEnemyAttack>().BasicAttack(other);
                    }
                    else
                    {
                        if (stateController.facingRight && !other.GetComponent<PlayerRotation>().isFacingRight ||
                            !stateController.facingRight && other.GetComponent<PlayerRotation>().isFacingRight)
                        {
                            root.GetComponent<Animator>().SetTrigger("Stunned");
                            HealPlayer();
                            root.GetComponent<MeleeEnemyState>().isStunned = true;
                            Debug.Log("EKEKE");
                            return;
                        }
                        else
                        {
                            root.GetComponent<BasicEnemyAttack>().BasicAttack(other);

                        }

                    }

                }

                break;





        }

        



    }

}
