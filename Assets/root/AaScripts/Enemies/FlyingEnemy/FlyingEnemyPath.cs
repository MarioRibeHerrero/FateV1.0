using System.Collections;
using UnityEngine;

public class FlyingEnemyPath : MonoBehaviour
{
    #region Vars
    private Rigidbody rb;
    private Transform target;
    private bool haveEntered;
    private int speed;



    //Pathing
    [Header("AttackShit")]
    [SerializeField] float animationTime, waitTime;
    [SerializeField] float attackForce;


    [Header("ResetVariables")]

    [SerializeField] int healthOnRestart;
    [SerializeField] Transform rayPos;

    [Header("PathingVars")]
    [SerializeField] int publicSpeed;
    [SerializeField] float rayHitDistance;




    //ResetShit
    // [SerializeField] GenericHealth healthGo;

    [SerializeField] FlyingEnemyState state;
    [SerializeField] FlyingEnemyHealth health;


    #endregion
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        health.health = 10;
        state.currentState = FlyingEnemyState.States.pathing;
        speed = -1;

    }

    private void OnEnable()
    {
        state.onEnemyReset += Reset;
    }

    private void OnDisable()
    {
        state.onEnemyReset -= Reset;
    }
    public void Reset()
    {
        state.currentState = FlyingEnemyState.States.pathing;
        health.health = healthOnRestart;
        rb.velocity = Vector3.zero;
   }

    private void Update()
    {
        if (state.currentState == FlyingEnemyState.States.pathing)
        {
            PathingTurnArround();

        }
    }
   
    private void PathingTurnArround()
    {
        transform.Translate(new Vector3(speed * publicSpeed, 0, 0) * Time.deltaTime);


        RaycastHit hit;

        //when it collides with those layers, it turns arround
        int layerMask = 8; 
        int layerMask2 = LayerMask.GetMask("FlyingEnemy");
        if (Physics.Raycast(rayPos.transform.position, -transform.right, out hit, rayHitDistance, layerMask) || Physics.Raycast(rayPos.transform.position, -transform.right, out hit, 5, layerMask2) && !haveEntered)
        {

            haveEntered = true;
            this.transform.eulerAngles = new Vector3(0, -180, 0);


        }
        if (Physics.Raycast(rayPos.transform.position, -transform.right, out hit, rayHitDistance, layerMask) && haveEntered)
        {

            
            haveEntered = false;
            this.transform.eulerAngles = new Vector3(0, 0, 0);

        }


    }
    private void OnDrawGizmos()
    {
        //draw the ray so we can see it

        Debug.DrawRay(rayPos.transform.position, -transform.right * rayHitDistance);

    }

    public IEnumerator AttackPlayer(Collider player)
    {
        state.currentState = FlyingEnemyState.States.attacking;
        //animacion prep ataque
        yield return new WaitForSeconds(animationTime);
        //Detectar Personaje
        target = player.transform;
        yield return new WaitForSeconds(waitTime);
        rb.velocity = Vector3.zero;
        //add the force to the hook
        Vector3 forceDirection = target.transform.position - transform.position;
        rb.AddForce(forceDirection.normalized * attackForce, ForceMode.Impulse);
        
    }



}