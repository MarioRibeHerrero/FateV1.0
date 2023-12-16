using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyAttack : MonoBehaviour
{


    [SerializeField] float damageTaken, stunTime, pushBackForce, pushBackForceOnCollision, damageTakenOnCollision;


    [SerializeField] Transform enemyBody;

    public void BasicAttack(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerHit>().HitPlayer(enemyBody.position, pushBackForce, stunTime, damageTaken, false);
          //  Debug.Log(this.transform.eulerAngles);
        }
    }



    public void HitHead(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerHit>().HitPlayer(enemyBody.position, 0, 0, damageTakenOnCollision, true);
            //  Debug.Log(this.transform.eulerAngles);
        }
    }

    public void HitBody(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerHit>().HitPlayer(enemyBody.position, pushBackForceOnCollision, stunTime, damageTakenOnCollision, false) ;
            //  Debug.Log(this.transform.eulerAngles);
        }
    }
}
