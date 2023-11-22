using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemyPath : MonoBehaviour
{
    //Pathing
    [SerializeField] float animationTime, waitTime;
    [SerializeField] float attackForce;

    private Rigidbody rb;
    private Transform target;
    public int health;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        health = 10;
    }

    // Update is called once per frame

    public IEnumerator AttackPlayer(Collider player)
    {
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


    public void TakeDamage(int damage)
    {
        health =- damage;

        if(health < 0)
        {
            Destroy(this);
        }
    }
}