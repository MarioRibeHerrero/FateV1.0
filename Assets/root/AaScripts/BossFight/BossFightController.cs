using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem.XR;
using System.Data.SqlTypes;

public class BossFightController : MonoBehaviour
{
    //FightLogic
    public delegate void OnApear();
    [HideInInspector] public OnApear onApear;
    [HideInInspector] public Vector3 spawnPos;
    [HideInInspector] public float bossTotalHealth, bossCurrentHealth;
    [HideInInspector] public bool stunRight;
    [HideInInspector] public int playerPos;
    [HideInInspector] public bool playerRight;
     public bool inSecondFace;
    [HideInInspector] public bool inBelzegorFight, bossFightFinished;
    //Cooldown
    [SerializeField] int comboCD;
    bool isComboInCD;
    [SerializeField] int pilarCD;
    bool isPilarInCD;
    int dashCD;
    int boomerangCD;

    private bool hasStartedSecondPhase;

    //References
    private BossUiManager bossUiManager;
    private BossHealth bHealth;
    //PlayerReference
    private PlayerHealth pHealth;
    //BossBody
    [SerializeField] Animator bodyAnimator;
    GameObject bodyGameObject;
    Animator anim;
    //attacks
    [Header("Attacks")]
    [SerializeField] GameObject spikeParent;
    //Possitions
    [Header("POSICIONES")]
    [SerializeField] Transform backPos;
    [SerializeField] Transform DashRight;
    [SerializeField] Transform DashLeft;
    [SerializeField] Transform midPoint;
    [SerializeField] Transform comboRight;
    [SerializeField] Transform comboLeft;

    private void Awake()
    {
        pHealth = GameObject.FindAnyObjectByType<PlayerHealth>();
        bossUiManager = GetComponent<BossUiManager>();
        bodyGameObject = bodyAnimator.transform.gameObject;
        bHealth = GetComponent<BossHealth>();
        anim = GetComponent<Animator>();
    }
    public void GetRandomBossAttack()
    {
        //check if in belzegor fight and if not reutr
        if (!inBelzegorFight) return;


        //animation Speed

        if (inSecondFace)
        {
            bodyAnimator.SetFloat("AfkAnimSpeed", 5);
            bodyAnimator.SetFloat("SecondFaceStun", 2.5f);
            anim.SetFloat("PilarSpeed", 1.5f);


        }
        else
        {
            bodyAnimator.SetFloat("AfkAnimSpeed", 1);
            bodyAnimator.SetFloat("SecondFaceStun", 1);
            anim.SetFloat("PilarSpeed", 1);

        }



        //get random attack
        int randomAttack = UnityEngine.Random.Range(1, 5);
        //set the onapear to null, so the boss wont call a method we dont want
        onApear = null;

        if(inSecondFace)
        {
            if (!hasStartedSecondPhase)
            {
                DesapearIntoNewPos(backPos.position);
                onApear += TransitionToSecondPashe;
                hasStartedSecondPhase = true;
                return;
            }
            Debug.Log("HOLA");
            switch (randomAttack)
            {
                case 1:
                    //CASE--->Ataque pilares
                    //Ponemos posicion a donde queremos
                    DesapearIntoNewPos(backPos.position);
                    //a?adimos metodo al evento
                    onApear += PilarAttack;
                    break;
                case 2:
                    //CASE--->Ataque Dash
                    if (UnityEngine.Random.Range(1, 11) !<= 4)
                    {
                        GetRandomBossAttack();
                        return;
                    }

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

                    if (playerRight)
                    {
                        DesapearIntoNewPos(comboLeft.position);

                        onApear += LeftToRightCombo;
                        stunRight = true;
                    }
                    else
                    {
                        DesapearIntoNewPos(comboRight.position);
                        onApear += RightToLeftCombo;
                        stunRight = false;
                    }
                    break;
            }
            return;
        }


        switch (randomAttack)
        {
            case 1:
                //CASE--->Ataque pilares

                //CoolDown Logic deberia entrar 1 de cada 4 como minimo,
                //Sale, 
                if(!isPilarInCD)
                {
                    //Ponemos posicion a donde queremos
                    DesapearIntoNewPos(backPos.position);
                    //a?adimos metodo al evento
                    onApear += PilarAttack;
                    isPilarInCD = true;
                    AddTopPilarCD();
                }
                else
                {
                    GetRandomBossAttack();
                }

                break;
            case 2:
                //CASE--->Ataque Dash

                //CoolDown Logic deberia entrar 2 veces seguidas como maximo


                if (dashCD == 2)
                {
                    GetRandomBossAttack();
                    return;
                }

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

                if (boomerangCD == 2)
                {
                    GetRandomBossAttack();
                    return;
                }



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

                if (!isComboInCD)
                {
                    if (playerRight)
                    {
                        DesapearIntoNewPos(comboLeft.position);

                        onApear += LeftToRightCombo;
                        stunRight = true;
                    }
                    else
                    {
                        DesapearIntoNewPos(comboRight.position);

                        onApear += RightToLeftCombo;
                        stunRight = false;
                    }

                    isComboInCD = true;
                    AddToComboCD();
                }
                else
                {
                    GetRandomBossAttack();
                }







                break;
        }

    }
    public void CallCombinedAttackDisk()
    {
        if(!inBelzegorFight) return;

        int randomAttack = UnityEngine.Random.Range(1, 3);

        switch(randomAttack)
        {
            case 1:
                //SALE DAHS
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
            case 2:
                //PILAR

                //Ponemos posicion a donde queremos
                DesapearIntoNewPos(backPos.position);
                //a?adimos metodo al evento
                onApear += PilarAttack;
                break;
        }
    }
    public void CallCombinedAttackPilar()
    {
        if(!inBelzegorFight) return;

        int randomAttack = UnityEngine.Random.Range(1, 3);

        switch (randomAttack)
        {
            case 1:
                //SALE DAHS

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
            case 2:

                //SALE DISCO

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
        }
    }

    public void ResetBossFight()
    {
        bossUiManager.DisableHealth();
        inBelzegorFight = false;
        pHealth.onPlayerDeath -= ResetBossFight;
        inSecondFace = false;
        hasStartedSecondPhase = false;

    }
    public void StartBossFight()
    {
        bossUiManager.EnableHealth();
        inBelzegorFight = true;
        pHealth.onPlayerDeath += ResetBossFight;
        bodyGameObject.transform.position = backPos.position;
        bHealth.SetHealth();
        anim.SetTrigger("StartBoosFight");
    }

    public void EndBossFight()
    {
        DesapearIntoNewPos(backPos.position);
        onApear += BossDied;
        Invoke("CloseTelones", 2f);
    }


    public void TransitionToSecondPashe()
    {
        bodyAnimator.SetTrigger("SecondPhase");

    }
    private void CloseTelones()
    {
        anim.SetTrigger("EndBossFight");
    }
    
    
    
    
    public void DesapearIntoNewPos(Vector3 whereToSpawn)
    {
        spawnPos = whereToSpawn;
        bodyAnimator.SetTrigger("Disappear");
    }
    public void StartBossFightBoss()
    {
        bodyAnimator.SetTrigger("StartBossFight");
    }



    private void BossDied()
    {
        bodyAnimator.SetTrigger("Die");
        bHealth.EndFight();

    }
    #region Attacks


    //Boomerang
    public void LeftSideAttact()
    {
        bodyAnimator.SetTrigger("LeftSideBoomerang");

        //CD
        AddTopPilarCD();
        DashCDTo0();
        BoomerangCDTPlus();
        AddToComboCD();


    }

    public void RightSideAttact()
    {
        bodyAnimator.SetTrigger("RightSideBoomerang");

        //CD
        AddTopPilarCD();
        DashCDTo0();
        BoomerangCDTPlus();
        AddToComboCD();


    }


    //Dash
    public void LeftToRightAttack()
    {
        bodyAnimator.SetTrigger("LeftToRightDash");

        //CD
        AddTopPilarCD();
        DashCDTPlus();
        BoomerangCDTo0();
        AddToComboCD();

    }

    public void RightToLeftAttack()
    {
        bodyAnimator.SetTrigger("RightToLeftDash");

        //CD
        AddTopPilarCD();
        DashCDTPlus();
        BoomerangCDTo0();
        AddToComboCD();

    }

    //Pilar Attack

    public void PilarAttack()
    {
        if(playerPos == 1) bodyAnimator.SetTrigger("PilarAttackSet1");
        else bodyAnimator.SetTrigger("PilarAttackSet2");


        //CD
        DashCDTo0();
        BoomerangCDTo0();
        AddToComboCD();
    }

    //Boss Combo Attack

    public void RightToLeftCombo()
    {
        bodyAnimator.SetTrigger("RightToLeftComboAttack");

        //CD
        AddTopPilarCD();
        DashCDTo0();
        BoomerangCDTo0();
    }
    public void LeftToRightCombo()
    {
        bodyAnimator.SetTrigger("LeftToRightComboAttack");

        //CD
        AddTopPilarCD();
        DashCDTo0();
        BoomerangCDTo0();
    }




    //CoolDown logic, all attacks sum up to the cd ints

    private void AddTopPilarCD()
    {
        if (isPilarInCD)
        {
            pilarCD++;
            if (pilarCD == 4)
            {
                pilarCD = 0;
                isPilarInCD = false;
            }
        }

    }
    private void AddToComboCD()
    {
        if (isComboInCD)
        {
            comboCD++;
            if (comboCD == 4)
            {
                comboCD = 0;
                isComboInCD = false;
            }
        }

    }
    private void DashCDTo0()
    {
        dashCD = 0;
    }
    private void DashCDTPlus()
    {
        dashCD++;
    }
    private void BoomerangCDTo0()
    {
        boomerangCD = 0;
    }
    private void BoomerangCDTPlus()
    {
        boomerangCD++;
    }


    #endregion


}


