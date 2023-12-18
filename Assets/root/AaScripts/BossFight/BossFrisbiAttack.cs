using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFrisbiAttack : MonoBehaviour
{
    private Animator anim;


    [SerializeField] GameObject bossBody;
    [SerializeField] Transform leftPos, rightPos;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.J)) 
        {
            StartCoroutine(FrisbiAttack());
        }
        
    }

    public IEnumerator FrisbiAttack()
    {
        anim.SetTrigger("Disappear");
        yield return new WaitForSeconds(1);
        int random = Random.Range(1, 3);
        SetBossToPosition(random);
        anim.SetTrigger("appear");
        yield return new WaitForSeconds(1);
        AttackPlayer(random);


        yield return new WaitForSeconds(3);
        //StartCoroutine(GetComponent<BossSpikeAttack>().SpikeAttack());


    }


    private void AttackPlayer(int number)
    {
        if (number == 1)
        {
            anim.SetTrigger("LeftToRightFrisbiAttack");
        }
        else
        {
            anim.SetTrigger("RightToLeftFrisbiAttack");

        }
    }
    private void SetBossToPosition(int number)
    {
        if(number == 1)
        {
            bossBody.transform.position = leftPos.transform.position;
            Debug.Log("Izqioerda");

        }
        else
        {
            bossBody.transform.position = rightPos.transform.position;
            Debug.Log("derecha");

        }
    }
}
