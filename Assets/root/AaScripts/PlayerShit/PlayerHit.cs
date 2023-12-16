using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerHit : MonoBehaviour
{

    [SerializeField] float invulnerabilityTime;
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.K))
        {
            HitPlayer(this.transform.position, 20, 1, 20, false);
        }
    }


    public void HitPlayer(Vector3 hitPosition,float pushBackForce, float stunTime, float damageTaken, bool takingSlow)
    {
        if (!GameManager.Instance.isPlayerInvulnerable)
        {
            if(takingSlow)
            {
                StartCoroutine(SlowPlayer());
                GameManager.Instance.isPlayerInvulnerable = true;
                Invoke(nameof(PlayerToVulnerable), stunTime + invulnerabilityTime);
                GetComponent<PlayerHealth>().TakeDamage(damageTaken);

            }
            else
            {
                anim.SetTrigger("PlayerHit");

                GameManager.Instance.isPlayerInvulnerable = true;
                Invoke(nameof(PlayerToVulnerable), stunTime + invulnerabilityTime);
                StartCoroutine(StunPlayer(stunTime, hitPosition, pushBackForce));
                GetComponent<PlayerHealth>().TakeDamage(damageTaken);
            }


        }
    }


    private void PlayerToVulnerable()
    {
        GameManager.Instance.isPlayerInvulnerable = false;
    }
    public void Kill()
    {
        GetComponent<PlayerHealth>().TakeDamage(100);
    }
    private void pushPlayer(Vector3 hitPosition, float pushBackForce)
    {


        Vector3 direction = transform.position - hitPosition;

        direction.Normalize();

        // Apply force in the opposite direction to push the object away
        GetComponent<Rigidbody>().drag = 7;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().AddForce(direction * pushBackForce, ForceMode.Impulse);
        

        //multiplicamos 1, x el signo de la rotacion, x lo que si esta miradno a la derecha, 1 lo empujara a la derecha, si esta en la izquierda,
        // sera menos 1 y lo empujara al otro lado.


        /*
        //Si el enemigo esta mirando a la derecha:
        if (hitPosition.y == 180)
        {
            //si el player mira a derecha se le empuja para atas, y si player mirando izquierda le empuja derecha
            Vector3 pushbackDirection = GetComponent<PlayerRotation>().isFacingRight ?  new Vector3(-1, 0, 0) : new Vector3(1, 0, 0);

            GetComponent<Rigidbody>().drag = 7;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().AddForce(pushbackDirection * pushBackForce, ForceMode.Impulse);
        }
        else
        {
            //si el player mira a izquierda se le empuja para atas, y si player mirando derecha le empuja derecha
            Vector3 pushbackDirection = GetComponent<PlayerRotation>().isFacingRight ? new Vector3(-1, 0, 0) : new Vector3(1, 0, 0);

            GetComponent<Rigidbody>().drag = 7;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().AddForce(pushbackDirection * pushBackForce, ForceMode.Impulse);
        }

        */








    }

    private IEnumerator StunPlayer(float stunTime, Vector3 hitPosition, float pushBackForce)
    {
        
        GameManager.Instance.isPlayerStunned = true;
        //Cosas q no puede hacer el player mientras este stuneado:
        //Moverse, rotar, atacar, parrear, 
        //abarca tmb el salto
        GameManager.Instance.canPlayerMove = false;
        GameManager.Instance.canPlayerRotate = false;
        //para que no pueda atacar el player ni parrear
        GameManager.Instance.inStrongAttack = true;
        GameManager.Instance.isOccupied = true;
        

        pushPlayer(hitPosition, pushBackForce);

        yield return new WaitForSeconds(stunTime);
        GameManager.Instance.isPlayerStunned = false;
        //Cosas q no puede hacer el player mientras este stuneado:
        //Moverse, rotar, atacar, parrear, 
        //abarca tmb el salto
        GameManager.Instance.canPlayerMove = true;
        GameManager.Instance.canPlayerRotate = true;
        //para que no pueda atacar el player ni parrear
        GameManager.Instance.inStrongAttack = false;
        GameManager.Instance.isOccupied = false;
    }

    private IEnumerator SlowPlayer()
    {
        Vector3 currentVel = GetComponent<Rigidbody>().velocity;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        yield return new WaitForSeconds(0.1f);
        //GetComponent<Rigidbody>().velocity = currentVel;
    }
}
