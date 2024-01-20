using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BossFightController : MonoBehaviour
{
    public bool inBelzegorFight, bossFightFinished;
   
    public bool inSecondFace;

    [HideInInspector] public float bossTotalHealth, bossCurrentHealth;


    public delegate void OnApear();
    public OnApear onApear;



    //References
    private BossUiManager bossUiManager;

    //BossAttackReferences


    //PlayerReference
    private PlayerHealth pHealth;




    [HideInInspector] public Vector3 spawnPos;
    
    [SerializeField] Animator bodyAnimator;
    GameObject bodyGameObject;



    [Header("POSICIONES")]
    [SerializeField] Transform backPos;

    [SerializeField] Transform DashRight;
    [SerializeField] Transform DashLeft;

    [SerializeField] Transform midPoint;


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.U))
        {
            StartBossFight();
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            ResetBossFight();
        }
    }
    private void Awake()
    {
        pHealth = GameObject.FindAnyObjectByType<PlayerHealth>();
        bossUiManager = GetComponent<BossUiManager>();
        bodyGameObject = bodyAnimator.transform.gameObject;

        //attacks

    }
    public void GetRandomBossAttack()
    {
        if (!inBelzegorFight) return;
        int randomAttack = UnityEngine.Random.Range(1, 4);

        Debug.Log(randomAttack);


        switch (randomAttack)
        {
            case 1:
                //CASE--->Ataque pilares

                //Ponemos posicion a donde queremos
                DesapearIntoNewPos(backPos.position);
                //añadimos metodo al evento
                onApear += PilarAttack;
                break;

            case 2:
                //CASE--->Ataque Dash
                int randomPos = UnityEngine.Random.Range(1, 3);
                switch (randomPos)
                {
                    case 1:
                        DesapearIntoNewPos(DashLeft.position);
                        onApear += LeftToRightAttack;

                        break;
                    case 2:
                        DesapearIntoNewPos(DashRight.position);
                        onApear += RightToLeftAttack;

                        break;

                }
                break;

            case 3:
                //CASE--->Ataque Disco
                int randomPos2 = UnityEngine.Random.Range(1, 3);
                switch (randomPos2)
                {
                    case 1:
                        DesapearIntoNewPos(DashLeft.position);
                        onApear += LeftSideAttact;

                        break;
                    case 2:
                        DesapearIntoNewPos(DashRight.position);
                        onApear += RightSideAttact;

                        break;

                }

                break;
            case 4:
                //CASE--->Ataque Combo
                int randomPos3 = UnityEngine.Random.Range(1, 3);
                DesapearIntoNewPos(midPoint.position);
                switch (randomPos3)
                {

                    case 1:
                        onApear += RightToLeftCombo;

                        break;
                    case 2:
                        onApear += RightToLeftCombo;

                        break;

                }

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
        bossUiManager.EnableHealth();
        inBelzegorFight = true;
        pHealth.onPlayerDeath += ResetBossFight;
        

        bodyGameObject.transform.position = backPos.position;
        Invoke(nameof(GetRandomBossAttack ),2);
    }


    public void DesapearIntoNewPos(Vector3 whereToSpawn)
    {
        spawnPos = whereToSpawn;
        bodyAnimator.SetTrigger("Disappear");
    }



    #region Attacks


    //Boomerang
    public void LeftSideAttact()
    {
        bodyAnimator.SetTrigger("LeftSideBoomerang");
    }

    public void RightSideAttact()
    {
        bodyAnimator.SetTrigger("RightSideBoomerang");

    }


    //Dash
    public void LeftToRightAttack()
    {
        bodyAnimator.SetTrigger("LeftToRightDash");
    }

    public void RightToLeftAttack()
    {
        bodyAnimator.SetTrigger("RightToLeftDash");

    }

    //Pilar Attack

    public void PilarAttack()
    {
        bodyAnimator.SetTrigger("PilarAttack");
    }

    //Boss Combo Attack

    public void RightToLeftCombo()
    {
        bodyAnimator.SetTrigger("RightToLeftComboAttack");
    }


    #endregion


}


