using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFrisbiAttack : MonoBehaviour
{
    private Animator anim;
    private BossFightController fightController;

    [SerializeField] GameObject bossBody;
    [SerializeField] Transform leftPos, rightPos;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        fightController = GetComponent<BossFightController>();
    }



    public IEnumerator FrisbiAttack()
    {
        anim.SetTrigger("Disappear");

        if (fightController.inSecondFace) yield return new WaitForSeconds(0.5f);
        else yield return new WaitForSeconds(1); int random = Random.Range(1, 3);

        SetBossToPosition(random);
        anim.SetTrigger("appear");

        if (fightController.inSecondFace) yield return new WaitForSeconds(0.5f);
        else yield return new WaitForSeconds(1);

        AttackPlayer(random);

        yield return new WaitForSeconds(fightController.timeBetweenAttacks);
        fightController.GetRandomBossAttack();

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
