using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemyPath : MonoBehaviour
{
    //Pathing
    [SerializeField] Transform pointA;
    [SerializeField] Transform pointB;
    [SerializeField] float chillSpeed = 5f;
    [SerializeField] float waitTime = 1f;
    private bool canMove;

    private Transform target;
    private bool isWaiting;

    void Start()
    {

        target = pointA;
        isWaiting = false;
    }

    // Update is called once per frame
    void Update()
    {
        //normal Path
        if (!isWaiting)
        {
            MoveTowardsTarget();
        }
    }
    void MoveTowardsTarget()
    {

        float step = chillSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.transform.position.x, transform.position.y, transform.position.z), step);

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
           // facingRight = true;
        }
        else
        {
            target = pointA;
           // facingRight = false;
        }
      //  UpdateLookPos();
        isWaiting = false;
    }
}
