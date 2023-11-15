using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class BasicEnemyAttack : MonoBehaviour
{


    [SerializeField] float damageTaken, stunTime, pushBackForce;



    public void BasicAttack(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerHit>().HitPlayer(this.transform.eulerAngles, pushBackForce, stunTime, damageTaken);
          //  Debug.Log(this.transform.eulerAngles);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            //collision.transform.GetComponent<PlayerHit>().HitPlayer(this.transform.eulerAngles, 50, 1, 10);

            Debug.Log(this.transform.name);
        }
      
    }
}
