using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private PlayerHealth playerh;



    public static GameManager Instance;
    private void Awake()
    {
        playerh = GameObject.FindAnyObjectByType<PlayerHealth>();



        Instance = this;

        //vars
        canPlayerRotate = true;
        canPlayerMove = true;
        isPlayerAlive = true;
        playerHealth = 100;
        isOccupied = false;
    }


    //PlayerThings
    public float playerHealth;
    public bool isPlayerAlive;
    public bool canPlayerMove, canPlayerRotate, isOccupied, isPlayerStunned, isPlayerInvulnerable, isPlayerParry;
    public int playerDamage;

    //dobleJump
    public bool canDobleJump;

    //GainedAbilities
    public bool isDobleJumpUnlocked, isHookUnlocked;

    //camera

    public bool isZoomed;
    public bool inBridge;


    public void HealPlayer(int healingAmmount)
    {
        playerh.HealPlayer(healingAmmount);
    }



    /*
    Lista de cosas que tendre q retablecer:
    Gamemanager.iszoomed;
    

      
     
     */
}