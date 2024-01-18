using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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




    public Vector3 spawnPos;
    [SerializeField] Transform backPos;
    [SerializeField] Animator anim;
    [SerializeField] GameObject body;

    

    private void Awake()
    {
        pHealth = GameObject.FindAnyObjectByType<PlayerHealth>();

        bossSpikeAttack = GetComponent<BossSpikeAttack>();
        bossFrisbiAttack = GetComponent<BossFrisbiAttack>();
        bossUiManager = GetComponent<BossUiManager>();
    }
    private void Update()
    {

    }
    public void GetRandomBossAttack()
    {
        if (!inBelzegorFight) return;
        int random = UnityEngine.Random.Range(1, 3);


        DesapearIntoAttack(backPos.position, "RisePilarAttack");

        switch (random)
        {

            case 1:

                break;

            case 2:

                break;
            case 3:
               // StartCoroutine(bossSpikeAttack.SpikeAttack());
                break;

        }
    }

    public void ResetBossFight()
    {
        bossUiManager.DisableHealth();
        inBelzegorFight = false;

        pHealth.onPlayerDeath -= ResetBossFight;

    }
    public void StartBossFight()
    {
        pHealth.onPlayerDeath += ResetBossFight;
        inBelzegorFight = true;
        bossUiManager.EnableHealth();

        body.transform.position = backPos.position;
        Invoke(nameof(GetRandomBossAttack ),2);
    }


    public void DesapearIntoAttack(Vector3 whereToSpawn, string attackAnim)
    {
        spawnPos = whereToSpawn;

        anim.SetTrigger("Disappear");
        body.GetComponent<BossCallAnimationEvents>().animationToCallNext = attackAnim;
    }



}


