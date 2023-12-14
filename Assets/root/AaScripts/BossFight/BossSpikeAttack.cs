using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpikeAttack : MonoBehaviour
{
    private Animator anim;

    [SerializeField] Transform spikeAttackPos;

    [SerializeField] GameObject bossBody;
    private void Awake()
    {
        anim = GetComponent<Animator>();
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



    }

}
