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

    private Transform target;
    private bool isWaiting;


    //FollowingPlayer
    GameObject player;
    public bool isAttacking;



    //attack
    [SerializeField] Transform attackRange;
    [SerializeField] LayerMask attackLayer;
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

                if (!isWaiting) MoveTowardsTarget();

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
        }
        else
        {
            target = pointA;
        }
        isWaiting = false;
    }



}