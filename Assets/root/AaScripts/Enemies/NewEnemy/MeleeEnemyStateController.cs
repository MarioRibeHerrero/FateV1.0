using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GridBrushBase;

public class MeleeEnemyStateController : MonoBehaviour, IDamageable
{
    #region Variables

    [Header("References")]
    [SerializeField] MeleeEnemyState stateManager;
    [SerializeField] Animator animator;
    [SerializeField] BasicEnemyHealth healthManager;


    public bool facingRight;

    //Pathing
    private Transform pointA;
    private Transform pointB;
    private Transform target;

    //tackingPlayer
    [Header("PlayerTacking")]
    private Transform playerTarget;
    [SerializeField] bool onGround;
    [SerializeField] Transform onGroundPos;
    [SerializeField] LayerMask walkeableLayers;

    [Header("PlayerAttacking")]
    //attackPlayer
    [SerializeField] Transform attackRangePos;
    [HideInInspector] public bool canAttack;
    [HideInInspector] public bool hasExitedDuringAttack;
    public bool inRangeOfAttack;

    //variables tester might want to try
    [Header("VariablesCambiables")]
    [SerializeField] float enemyMovementSpeedDefault;
    private float enemyMovementSpeed;
    [SerializeField] float timeEnemyWaits;
    [SerializeField] Vector3 attackRangeVector;
    [SerializeField] LayerMask attackLayer;
    [SerializeField] float patienceDefault;
     float patience;




    //reset shit
    #endregion




    public void TakeDamage(int damage)
    {
        healthManager.TakeDamage(damage);
    }




    private void Awake()
    {
        playerTarget = GameObject.FindAnyObjectByType<PlayerGravity>().transform;
        //Pathing
        pointA = transform.parent.transform.Find("PathPoints").transform.Find("PointA");
        pointB = transform.parent.transform.Find("PathPoints").transform.Find("PointB");

        stateManager.onEnemyReset += Reset;

        
    }
    
    private void Start()
    {
        target = pointA;
        canAttack = true;
        
        
        patience = patienceDefault;
        enemyMovementSpeed = enemyMovementSpeedDefault;
    }

    void Update()
    {
        EnemyStateManagement();
    }


    private void Reset()
    {
        canAttack = true;
        transform.localPosition = Vector3.zero;
        stateManager.state = MeleeEnemyState.MeleeEnemyStateEnum.Pathing;
    }


    private void EnemyStateManagement()
    {
        switch (stateManager.state)
        {
            case MeleeEnemyState.MeleeEnemyStateEnum.Pathing:

                //MoveTowardsTarget();
                CheckIfPlayerInZone();
                break;
            case MeleeEnemyState.MeleeEnemyStateEnum.Waiting:
                break;
            case MeleeEnemyState.MeleeEnemyStateEnum.Attacking:
                Attack();
                break;
            case MeleeEnemyState.MeleeEnemyStateEnum.Tracking:

                FollowPlayer();
                CheckForGround();
                CheckAttack();
                break;


        }
    }

    #region WaitTimes


    public void WaitFor(float seconds)
    {
        StartCoroutine(WaitForSeconds(seconds));
    }

    private IEnumerator WaitForSeconds(float seconds)
    {
        stateManager.state = MeleeEnemyState.MeleeEnemyStateEnum.Waiting;

        yield return new WaitForSeconds(seconds);

        if (stateManager.playerInMovingZone)
        {
            stateManager.state = MeleeEnemyState.MeleeEnemyStateEnum.Tracking;
        }
        else stateManager.state = MeleeEnemyState.MeleeEnemyStateEnum.Pathing;

    }
    #endregion


    #region Pathing

    void MoveTowardsTarget()
    {

        float step = enemyMovementSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.transform.position.x, transform.position.y, transform.position.z), step);
        //if target is = to point b, faicing right will be true, else, it will be false.

        if (Vector3.Distance(transform.position, new Vector3(target.transform.position.x, transform.position.y, transform.position.z)) < 0.01f)
        {
            StartCoroutine(WaitAtPoint());
        }
        FaceTarget();
    }
    IEnumerator WaitAtPoint()
    {
        stateManager.state = MeleeEnemyState.MeleeEnemyStateEnum.Waiting;
            
            
        yield return new WaitForSeconds(timeEnemyWaits);

        if (target == pointA)
        {
            target = pointB;
        }
        else
        {
            target = pointA;
        }

        if (stateManager.state == MeleeEnemyState.MeleeEnemyStateEnum.Waiting) stateManager.state = MeleeEnemyState.MeleeEnemyStateEnum.Pathing;

    }
    private void FaceTarget()
    {

        if (target == pointB)
        {
            if (transform.position.x > pointB.transform.position.x) facingRight = false;
            else facingRight = true;
        }
        else
        {
            if (transform.position.x > pointA.transform.position.x) facingRight = false;
            else facingRight = true;
        }


        if (facingRight) transform.rotation = Quaternion.Euler(0, 180, 0);
        else transform.rotation = Quaternion.Euler(0, 0, 0);

    }

    private void CheckIfPlayerInZone()
    {
        if(stateManager.playerInMovingZone)
        {
            stateManager.state = MeleeEnemyState.MeleeEnemyStateEnum.Tracking;

        }
    }

    #endregion

    #region Tracking

    void FollowPlayer()
    {
        if(!stateManager.playerInMovingZone) stateManager.state = MeleeEnemyState.MeleeEnemyStateEnum.Pathing;
        if (onGround )
        {
            Vector3 targetPosition = new Vector3(playerTarget.transform.position.x, transform.position.y, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, enemyMovementSpeed * Time.deltaTime);
            
        }
        FacePlayer();

    }
    private void FacePlayer()
    {
        if (playerTarget.transform.position.x >= transform.position.x)
        {
            facingRight = true;
            if (facingRight) transform.rotation = Quaternion.Euler(0, 180, 0);
            else transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            facingRight = false;
            if (facingRight) transform.rotation = Quaternion.Euler(0, 180, 0);
            else transform.rotation = Quaternion.Euler(0, 0, 0);
        }

    }


    private void CheckForGround()
    {
        



        onGround = Physics.Raycast(onGroundPos.position, Vector3.down, 1, walkeableLayers);

        if (onGround)
        {
            Quaternion rotation = onGroundPos.transform.rotation;
            Vector3 direction = rotation * Vector3.right;

            onGround = !Physics.Raycast(onGroundPos.position, direction, 1f, walkeableLayers);
        }
    }


    #endregion

    #region Attack


    private void CheckAttack()
    {

        inRangeOfAttack = Physics.OverlapBox(attackRangePos.position, attackRangeVector / 2, Quaternion.identity, attackLayer).Length > 0;

        if (Physics.OverlapBox(attackRangePos.position, attackRangeVector / 2, Quaternion.identity, attackLayer).Length > 0)
        {
            patience -= Time.deltaTime;
            enemyMovementSpeed = 0f;
        }
        else enemyMovementSpeed = enemyMovementSpeedDefault;


        if (patience < 0)
        {
            stateManager.state = MeleeEnemyState.MeleeEnemyStateEnum.Attacking;
        }
    }

    private void Attack()
    {
        if (canAttack)
        {
            animator.SetTrigger("Attack");
            patience = patienceDefault;
            canAttack = false;
        }



    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(attackRangePos.position, attackRangeVector);



        Vector3 startPoint = onGroundPos.position;
        Quaternion rotation = onGroundPos.rotation;
        Vector3 direction = Vector3.down ;
        Vector3 endPoint = startPoint + direction * 1;
        Vector3 endPoint2 = startPoint + rotation * Vector3.right * 1;

        Gizmos.DrawLine(startPoint, endPoint);
        Gizmos.DrawLine(startPoint, endPoint2);
    }

    #endregion

}
