using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemyPath : MonoBehaviour, IReseteable
{
    //Pathing
    [SerializeField] float animationTime, waitTime;
    [SerializeField] float attackForce;

    private Rigidbody rb;
    private Transform target;
    public int health;



    private bool canMove;
    [SerializeField] int speed;
    [SerializeField] Transform rayPos;



    bool haveEntered;



    //ResetShit
   // [SerializeField] GenericHealth healthGo;
    

    public void Reset()
    {
       // healthGo.health = health;
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

    }
    void Start()
    {
        health = 10;


        canMove = true;
    }


    private void Update()
    {
        RaycastHit hit;

        int layerMask = LayerMask.GetMask("Ground"); // Adjust "Wall" to the actual layer name
        int layerMask2 = LayerMask.GetMask("FlyingEnemy");
        if (Physics.Raycast(rayPos.transform.position, -transform.right, out hit, 5, layerMask) || Physics.Raycast(rayPos.transform.position, -transform.right, out hit, 5, layerMask2) && !haveEntered)
        {
            
            //speed = speed * -1;
            haveEntered = true;
            this.transform.eulerAngles = new Vector3(0, -180, 0);


        }
        if (Physics.Raycast(rayPos.transform.position, -transform.right, out hit, 5, layerMask) && haveEntered)
        {

           // speed = speed * -1;
            haveEntered = false;
            this.transform.eulerAngles = new Vector3(0, 0, 0);

        }


        Debug.DrawRay(rayPos.transform.position, -transform.right * 5);

    }
    private void FixedUpdate()
    {
        if (canMove)
        {
            transform.Translate(new Vector3(speed *0.1f,0,0));
        }
    }






    public IEnumerator AttackPlayer(Collider player)
    {
        canMove = false;
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