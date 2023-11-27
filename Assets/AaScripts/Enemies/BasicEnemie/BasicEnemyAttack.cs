using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class BasicEnemyAttack : MonoBehaviour
{


    [SerializeField] float damageTaken, stunTime, pushBackForce, pushBackForceOnCollision, damageTakenOnCollision;



    public void BasicAttack(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerHit>().HitPlayer(this.transform.eulerAngles, pushBackForce, stunTime, damageTaken, false);
          //  Debug.Log(this.transform.eulerAngles);
        }
    }



    public void HitHead(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerHit>().HitPlayer(this.transform.eulerAngles, 0, 0, damageTakenOnCollision, true);
            //  Debug.Log(this.transform.eulerAngles);
        }
    }

    public void HitBody(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerHit>().HitPlayer(this.transform.eulerAngles, pushBackForceOnCollision, stunTime, damageTakenOnCollision, false) ;
            //  Debug.Log(this.transform.eulerAngles);
        }
    }
}
