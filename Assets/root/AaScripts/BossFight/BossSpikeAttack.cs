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

        if(fightController.inSecondFace) yield return new WaitForSeconds(0.5f);
        else yield return new WaitForSeconds(1);


        bossBody.transform.position = spikeAttackPos.transform.position;
        anim.SetTrigger("appear");

        if (fightController.inSecondFace) yield return new WaitForSeconds(0.5f);
        else yield return new WaitForSeconds(1);

        Debug.Log("GOLA");
        anim.SetTrigger("SpikeAttack");


        yield return new WaitForSeconds(fightController.timeBetweenAttacks);
        fightController.GetRandomBossAttack();
    }
    public void Reset()
    {
        StopAllCoroutines();
    }

}
