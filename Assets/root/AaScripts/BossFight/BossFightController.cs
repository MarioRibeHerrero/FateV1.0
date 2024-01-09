using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFightController : MonoBehaviour
{
    public bool inBelzegorFight, bossFightFinished;
    public float bossTotalHealth, bossCurrentHealth;
    public float hitTime;
    public int timeBetweenAttacks;
    public bool inSecondFace;


    //AttackReferences
    private BossSpikeAttack bossSpikeAttack;
    private BossFrisbiAttack bossFrisbiAttack;
    private BossUiManager bossUiManager;

    //PlayerReference
    private PlayerHealth pHealth;

    private void Awake()
    {
        pHealth = GameObject.FindAnyObjectByType<PlayerHealth>();

        bossSpikeAttack = GetComponent<BossSpikeAttack>();
        bossFrisbiAttack = GetComponent<BossFrisbiAttack>();
        bossUiManager = GetComponent<BossUiManager>();
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


    public void StartBossFight()
    {
        pHealth.onPlayerDeath += ResetBossFight;
        inBelzegorFight = true;
        Invoke(nameof(GetRandomBossAttack), 2f);
        bossUiManager.EnableHealth();
    }

    public void ResetBossFight()
    {
        bossUiManager.DisableHealth();
        inBelzegorFight = false;

        pHealth.onPlayerDeath -= ResetBossFight;

    }

}
