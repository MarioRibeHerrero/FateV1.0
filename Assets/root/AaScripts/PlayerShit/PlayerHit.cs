using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerHit : MonoBehaviour
{

    [SerializeField] float invulnerabilityTime;
    private Animator anim;
    PlayerManager pManager;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        pManager = GetComponent<PlayerManager>();
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
        if (!pManager.isPlayerInvulnerable)
        {
            if(takingSlow)
            {
                StartCoroutine(SlowPlayer());
                pManager.isPlayerInvulnerable = true;
                Invoke(nameof(PlayerToVulnerable), stunTime + invulnerabilityTime);
                GetComponent<PlayerHealth>().TakeDamage(damageTaken);

            }
            else
            {
                anim.SetTrigger("PlayerHit");

                pManager.isPlayerInvulnerable = true;
                Invoke(nameof(PlayerToVulnerable), stunTime + invulnerabilityTime);
                StartCoroutine(StunPlayer(stunTime, hitPosition, pushBackForce));
                GetComponent<PlayerHealth>().TakeDamage(damageTaken);
            }


        }
    }


    private void PlayerToVulnerable()
    {
        pManager.isPlayerInvulnerable = false;
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

    }

    private IEnumerator StunPlayer(float stunTime, Vector3 hitPosition, float pushBackForce)
    {
        
        pManager.isPlayerStunned = true;
        //Cosas q no puede hacer el player mientras este stuneado:
        //Moverse, rotar, atacar, parrear, 
        //abarca tmb el salto
        pManager.canPlayerMove = false;
        pManager.canPlayerRotate = false;
        //para que no pueda atacar el player ni parrear
        pManager.inStrongAttack = true;
        pManager.playerInNormalAttack = true;
        

        pushPlayer(hitPosition, pushBackForce);

        yield return new WaitForSeconds(stunTime);
        pManager.isPlayerStunned = false;
        //Cosas q no puede hacer el player mientras este stuneado:
        //Moverse, rotar, atacar, parrear, 
        //abarca tmb el salto
        pManager.canPlayerMove = true;
        pManager.canPlayerRotate = true;
        //para que no pueda atacar el player ni parrear
        pManager.inStrongAttack = false;
        pManager.playerInNormalAttack = false;
    }

    private IEnumerator SlowPlayer()
    {
        Vector3 currentVel = GetComponent<Rigidbody>().velocity;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        yield return new WaitForSeconds(0.1f);
        //GetComponent<Rigidbody>().velocity = currentVel;
    }
}
