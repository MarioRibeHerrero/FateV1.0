using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasicEnemyPathing : MonoBehaviour
{





    [SerializeField] GameObject parent;
    //Pathing
    [SerializeField] Transform pointA;
    [SerializeField] Transform pointB;
    [SerializeField] float chillSpeed = 5f;
    [SerializeField] float waitTime = 1f;
    private bool canMove;

    private Transform target;
    private bool isWaiting;


    //FollowingPlayer
    GameObject player;
    public bool isAttacking;
    


    private bool facingRight;

    //attack
    [SerializeField] Transform attackRange;
    [SerializeField] LayerMask attackLayer;
    [SerializeField] float timer = 0;
    [SerializeField] Vector3 attackRangeVector;

    public bool stunned;
    //animations

    private Animator anim;







    [SerializeField] MeleeEnemyState stateManager;



    private void Awake()
    {
        //Components from root
        anim = parent.GetComponent<Animator>();
        player = GameObject.FindWithTag("Player");

    }
    void Start()
    {


        target = pointA;
        isWaiting = false;
        facingRight = true;

        
    }

    void Update()
    {

        EnemyStateManagement();

    }

    private void EnemyStateManagement()
    {
        switch (stateManager.state)
        {
            case MeleeEnemyState.MeleeEnemyStateEnum.Pathing:

                if(!isWaiting) MoveTowardsTarget();

                break;
            case MeleeEnemyState.MeleeEnemyStateEnum.Waiting:

                

                break;


        }
    }
    void MoveTowardsTarget()
    {

        float step = chillSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.transform.position.x, transform.position.y, transform.position.z), step);
        //if target is = to point b, faicing right will be true, else, it will be false.

        if (Vector3.Distance(transform.position, new Vector3(target.transform.position.x, transform.position.y, transform.position.z)) < 0.01f)
        {
            StartCoroutine(WaitAtPoint());
        }
    }

    IEnumerator WaitAtPoint()
    {
        isWaiting = true;
        yield return new WaitForSeconds(waitTime);

        if (target == pointA)
        {
            target = pointB;
            facingRight = true;
        }
        else
        {
            target = pointA;
            facingRight = false;
        }
        isWaiting = false;
    }



















    /*



    private void prueba()
    {

        switch (state.enemyState)
        {

            case 1:
                //normal Path
                if (!isWaiting && !isAttacking)
                {
                    MoveTowardsTarget();
                }

                break;

            case 2:
                //Follow player
                if (canMove && !stunned) FollowPlayer();

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

                if (!isAttacking)
                {
                    state.enemyState = 2;
                }

                break;
        }

        ControlAttacktimer();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(attackRange.position, attackRangeVector);
    }
    private bool CanAttack()
    {
        
        bool canAttack;

        if(Physics.OverlapBox(attackRange.position, attackRangeVector / 2, Quaternion.identity, attackLayer).Length > 0 && timer >= 0.01f)
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
        if (Physics.OverlapBox(attackRange.position, attackRangeVector / 2, Quaternion.identity, attackLayer).Length > 0)
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
        Vector3 targetPosition = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, chillSpeed * Time.deltaTime);


        FacePlayer();
    }








    public void RandomTarget()
    {
        int random = Random.Range(1,3);

        if(random == 1)
        {
            target = pointA;
            facingRight = false;
        }
        else
        {
            target = pointB;
            facingRight = true;
        }
        
    }

    public IEnumerator WaitFor(int secs)
    {
        isWaiting = true;
        yield return new WaitForSeconds(secs);
        isWaiting = false;
    }
    IEnumerator WaitAtPoint()
    {
        isWaiting = true;
        yield return new WaitForSeconds(waitTime);
       
        if (target == pointA)
        {
            target = pointB;
            facingRight = true;
        }
        else
        {
            target = pointA;
            facingRight = false;
        }
        UpdateLookPos();
        isWaiting = false;
    }


    private void FaceTarget()
    {
        facingRight = target == pointB;


        if(target == pointB)
        {
            if (transform.position.x > pointB.transform.position.x) facingRight = false;
            else facingRight = true;
        }
        else
        {
            if (transform.position.x > pointA.transform.position.x) facingRight = false;
            else facingRight = true;
        }
    }
    private void UpdateLookPos()
    {
        if ( !isAttacking)
        {
            if (facingRight) transform.rotation = Quaternion.Euler(0, 180, 0);
            else transform.rotation = Quaternion.Euler(0, 0, 0);
        }

    }
    private void FacePlayer()
    {
        if (player.transform.position.x >= transform.position.x)
        {
            facingRight = true;
            UpdateLookPos();
        }
        else
        {
            facingRight = false;
            UpdateLookPos();
        }

    }


    */

}





