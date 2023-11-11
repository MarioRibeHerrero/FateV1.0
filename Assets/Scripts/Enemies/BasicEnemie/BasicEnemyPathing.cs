using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyPathing : MonoBehaviour
{
    //Pathing
    [SerializeField] Transform pointA;
    [SerializeField] Transform pointB;
    [SerializeField] float chillSpeed = 5f;
    [SerializeField] float waitTime = 1f;

    private Transform target;
    private bool isWaiting;


    //FollowingPlayer
    [SerializeField] GameObject player;
    [SerializeField] float followSpeed, attackDistance;
    public bool isAttacking;



    private bool facingRight;

    //attack
    [SerializeField] BasicEnemyAttack attack;



    void Start()
    {
        target = pointA;
        isWaiting = false;
        facingRight = true;
        UpdateLookPos();
    }

    void Update()
    {



        switch(GetComponent<BasicEnemyState>().enemyState)
        {

            case 1:

                if (!isWaiting)
                {
                    MoveTowardsTarget();
                }

                break;

                case 2:
                if (!isAttacking)
                {
                    float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

                    if (distanceToPlayer <= attackDistance)
                    {
                        attack.Attack();
                        Debug.Log("GOA");
                    }
                    else
                    {
                
                        FollowPlayer();
                    }
                }
                break;
        }
    }





    void FollowPlayer()
    {
        // Calculate the direction towards the player
        Vector3 direction = (new Vector3(player.transform.position.x, transform.position.y, transform.position.z) - transform.position).normalized;


        GetComponent<Rigidbody>().MovePosition(transform.position + direction * followSpeed * Time.deltaTime);
    }





    void MoveTowardsTarget()
    {
        float step = chillSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.transform.position.x, transform.position.y,transform.position.z), step);

        if (Vector3.Distance(transform.position, new Vector3(target.transform.position.x, transform.position.y, transform.position.z)) < 0.01f)
        {
            StartCoroutine(WaitAtPoint());
        }
    }

    IEnumerator WaitAtPoint()
    {
        isWaiting = true;
        yield return new WaitForSeconds(waitTime);
        if(facingRight) facingRight = false;
        else facingRight = true;
        UpdateLookPos();
        if (target == pointA)
        {
            target = pointB;
        }
        else
        {
            target = pointA;
        }

        isWaiting = false;
    }

    private void UpdateLookPos()
    {
        if(facingRight) transform.rotation = Quaternion.Euler(0, 180, 0);
        else transform.rotation = Quaternion.Euler(0, 0, 0);
    }




}

