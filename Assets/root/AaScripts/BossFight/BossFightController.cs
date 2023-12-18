using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFightController : MonoBehaviour
{
    public bool inBossFight, bossFightFinished;
    public float bossTotalHealth, bossCurrentHealth;
    public float hitTime;

    public int timeBetweenAttacks;


    private BossSpikeAttack bossSpikeAttack;
    private BossFrisbiAttack bossFrisbiAttack;


    private void Awake()
    {
        bossSpikeAttack = GetComponent<BossSpikeAttack>();
        bossFrisbiAttack = GetComponent<BossFrisbiAttack>();
    }

    public void GetRandomBossAttack()
    {

        int random = Random.Range(1, 3);
        
        switch (random)
        {

            case 1:
                StartCoroutine(bossSpikeAttack.SpikeAttack());
                break;

            case 2:
                StartCoroutine(bossFrisbiAttack.FrisbiAttack());
                break;

        }
    }
}
