using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasicEnemyPathing : MonoBehaviour
{
    //Pathing
    [SerializeField] Transform pointA;
    [SerializeField] Transform pointB;
    [SerializeField] float chillSpeed = 5f;
    [SerializeField] float waitTime = 1f;
    private bool canMove;

    private Transform target;
    private bool isWaiting;


    //FollowingPlayer
    [SerializeField] GameObject player;
    [SerializeField] float followSpeed, attackDistance;
    public bool isAttacking;



    private bool facingRight;

    //attack
    BasicEnemyState state;
    [SerializeField] Transform attackRange;
    [SerializeField] LayerMask attackLayer;
    [SerializeField] float timer = 0;

    public bool stunned;
    //animations

    private Animator anim;


    void Start()
    {

        //Components from root
        anim = transform.root.GetComponent<Animator>();
        state = transform.root.GetComponent<BasicEnemyState>();


        target = pointA;
        isWaiting = false;
        facingRight = true;
        UpdateLookPos();

        
    }

    void Update()
    {
        switch(transform.root.GetComponent<BasicEnemyState>().enemyState)
        {

            case 1:
                //normal Path
                if (!isWaiting)
                {
                    MoveTowardsTarget();
                }

                break;

                case 2:
                //Follow player
                if(canMove && !stunned) FollowPlayer();

                //si estas en rango, atacas
                if (CanAttack() && !stunned)
                 {
                    anim.SetTrigger("Attack");
                    isAttacking = true;
                    state.enemyState = 3;

                 }

                
                break;

            case 3:
                //attack

                if(!isAttacking)
                {
                    state.enemyState = 2;
                }

                break;
        }

        ControlAttacktimer();
    }



    private bool CanAttack()
    {
        
        bool canAttack;

        if(Physics.OverlapBox(attackRange.position, new Vector3(0.9f, 0.8f, 0.5f), Quaternion.identity, attackLayer).Length > 0 && timer >= 0.01f)
        {
            
            canAttack = true;
            timer = 0;
            return canAttack;
        }
        else
        {
            canAttack = false;
            return canAttack;
        }

        
    }
    private void ControlAttacktimer()
    {
        if (Physics.OverlapBox(attackRange.position, new Vector3(0.9f, 0.8f, 0.5f), Quaternion.identity, attackLayer).Length > 0)
        {
            timer += Time.deltaTime;
            canMove = false;
        }
        else
        {
            timer = 0;
            canMove = true;
        }
    }



    void FollowPlayer()
    {
        // Calculate the direction towards the player
        Vector3 direction = (new Vector3(player.transform.position.x, transform.position.y, transform.position.z) - transform.position).normalized;
        GetComponent<Rigidbody>().MovePosition(transform.position + direction * followSpeed * Time.deltaTime);



        FacePlayer();
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


    public void RandomTarget()
    {
        int random = Random.Range(1,3);

        if(random == 1)
        {
            target = pointA;
            facingRight = true;
        }
        else
        {
            target = pointB;
            facingRight = false;
        }
        UpdateLookPos();
    }

    IEnumerator WaitAtPoint()
    {
        isWaiting = true;
        yield return new WaitForSeconds(waitTime);
       
        if (target == pointA)
        {
            target = pointB;
            facingRight = false;
        }
        else
        {
            target = pointA;
            facingRight = true;
        }
        UpdateLookPos();
        isWaiting = false;
    }

    private void UpdateLookPos()
    {
        if(facingRight) transform.rotation = Quaternion.Euler(0, 180, 0);
        else transform.rotation = Quaternion.Euler(0, 0, 0);
    }
    private void FacePlayer()
    {
        if (player.transform.position.x >= transform.position.x)
        {
            facingRight = false;
            UpdateLookPos();
        }
        else
        {
            facingRight = true;
            UpdateLookPos();
        }

    }

}





