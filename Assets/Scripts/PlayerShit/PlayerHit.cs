using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    



    public void HitPlayer(Vector3 hitPosition,float pushBackForce, float stunTime, float damageTaken)
    {

        StartCoroutine(StunPlayer(stunTime, hitPosition, pushBackForce));
        GetComponent<PlayerHealth>().TakeDamage(damageTaken);
    }



    private void pushPlayer(Vector3 hitPosition, float pushBackForce)
    {

        //multiplicamos 1, x el signo de la rotacion, x lo que si esta miradno a la derecha, 1 lo empujara a la derecha, si esta en la izquierda,
        // sera menos 1 y lo empujara al otro lado.
        Vector3 pushbackDirection = hitPosition.y == 180 ? new Vector3(1, 0, 0) : new Vector3(-1, 0, 0);

        if (GetComponent<PlayerGroundCheck>().isPlayerGrounded)
        {
            GetComponent<Rigidbody>().drag = 7;

            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().AddForce(pushbackDirection * pushBackForce, ForceMode.Impulse);
        }
        else
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().AddForce(pushbackDirection * pushBackForce / 4, ForceMode.Impulse);
        }
    }

    private IEnumerator StunPlayer(float stunTime, Vector3 hitPosition, float pushBackForce)
    {
        
        GameManager.Instance.isPlayerStunned = true;
        //Cosas q no puede hacer el player mientras este stuneado:
        //Moverse, rotar, atacar, parrear, 
        GetComponent<PlayerMovement>().enabled = false;
        GetComponent<PlayerRotation>().enabled = false;
        GetComponent<PlayerJump>().enabled = false;
        GetComponent<PlayerParry>().enabled = false;
        GetComponent<PlayerAa>().enabled = false;
        GetComponent<PlayerHook>().enabled = false;
        pushPlayer(hitPosition, pushBackForce);

        yield return new WaitForSeconds(stunTime);
        GameManager.Instance.isPlayerStunned = false;



        GetComponent<PlayerMovement>().enabled = true;
        GetComponent<PlayerRotation>().enabled = true;
        GetComponent<PlayerJump>().enabled = true;
        GetComponent<PlayerParry>().enabled = true;
        GetComponent<PlayerAa>().enabled = true;
        GetComponent<PlayerHook>().enabled = true;
    }
}
