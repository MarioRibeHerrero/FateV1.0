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
     MeleeEnemyState stateManager;
     Animator animator;
     BasicEnemyHealth healthManager;
    DissolvingControllerTut disolveEffect;



    public bool facingRight;


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
    public float enemyMovementSpeedDefault;
    public float enemyMovementSpeed;
    [SerializeField] Vector3 attackRangeVector;
    [SerializeField] LayerMask attackLayer;
    public float patienceDefault;
    public float patience;

    //reset shit
    #endregion




    public void TakeDamage(int damage)
    {
        healthManager.TakeDamage(damage);
    }




    private void Awake()
    {
        playerTarget = GameObject.FindAnyObjectByType<PlayerGravity>().transform;
        animator = GetComponent<Animator>();
        healthManager = GetComponent<BasicEnemyHealth>();
        stateManager = GetComponent<MeleeEnemyState>();
        disolveEffect = GetComponent<DissolvingControllerTut>();
    }
    
    private void Start()
    {
        stateManager.onEnemyReset += Reset;
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
        //transform.localPosition = Vector3.zero;
        stateManager.state = MeleeEnemyState.MeleeEnemyStateEnum.Pathing;
        healthManager.isDead = false;
        disolveEffect.Reset();
    }


    private void EnemyStateManagement()
    {
        switch (stateManager.state)
        {
            case MeleeEnemyState.MeleeEnemyStateEnum.Pathing:
                animator.SetBool("IsMoving", false);

                CheckIfPlayerInZone();
                break;
            case MeleeEnemyState.MeleeEnemyStateEnum.Attacking:
                animator.SetBool("IsMoving", false);

                Attack();
                break;
            case MeleeEnemyState.MeleeEnemyStateEnum.Tracking:
                animator.SetBool("IsMoving", true);
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
            if (facingRight) transform.rotation = Quaternion.Euler(0, 90, 0);
            else transform.rotation = Quaternion.Euler(0, -90, 0);
        }
        else
        {
            facingRight = false;
            if (facingRight) transform.rotation = Quaternion.Euler(0, 90, 0);
            else transform.rotation = Quaternion.Euler(0, -90, 0);
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

        if (inRangeOfAttack)
        {
            animator.SetBool("IsMoving", false);

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
