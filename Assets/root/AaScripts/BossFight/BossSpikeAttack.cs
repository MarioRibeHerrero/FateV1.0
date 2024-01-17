using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpikeAttack : MonoBehaviour
{
    [SerializeField] Animator anim;
    private BossFightController fightController;

    [SerializeField] Transform spikeAttackPos;

    [SerializeField] GameObject bossBody;
    private void Awake()
    {
        fightController = GetComponent<BossFightController>();

    }

    public void Attack()
    {
       
    }



    private void CallSpikeAttack()
    {
        anim.SetTrigger("SpikeAttack");
    }
    public IEnumerator SpikeAttack()
    {
        anim.SetTrigger("Disappear");

        if(fightController.inSecondFace) yield return new WaitForSeconds(0.5f);
        else yield return new WaitForSeconds(1);


        bossBody.transform.position = spikeAttackPos.transform.position;
        anim.SetTrigger("appear");

        if (fightController.inSecondFace) yield return new WaitForSeconds(0.5f);
        else yield return new WaitForSeconds(1);

        Debug.Log("GOLA");
        anim.SetTrigger("SpikeAttack");

        if (!fightController.inBelzegorFight) yield break;

        yield return new WaitForSeconds(fightController.timeBetweenAttacks);
        fightController.GetRandomBossAttack();
    }


}
