using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpikeAttack : MonoBehaviour
{
    private Animator anim;
    private BossFightController fightController;

    [SerializeField] Transform spikeAttackPos;

    [SerializeField] GameObject bossBody;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        fightController = GetComponent<BossFightController>();

    }
    public IEnumerator SpikeAttack()
    {
        anim.SetTrigger("Disappear");
        yield return new WaitForSeconds(1);
        bossBody.transform.position = spikeAttackPos.transform.position;
        anim.SetTrigger("appear");

        yield return new WaitForSeconds(2);
        Debug.Log("GOLA");
        anim.SetTrigger("SpikeAttack");


        yield return new WaitForSeconds(fightController.timeBetweenAttacks);
        fightController.GetRandomBossAttack();
    }

}
