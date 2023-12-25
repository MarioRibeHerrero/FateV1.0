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
        playerDamage = playerDefaultDamage;
    }


    //PlayerThings
    public float playerHealth;
    public bool isPlayerAlive;
    public bool canPlayerMove, canPlayerRotate, isOccupied, isPlayerStunned, isPlayerInvulnerable, isPlayerParry;
    [HideInInspector] public int playerDamage;
    public int playerDefaultDamage;
    public bool inStrongAttack;
    //dobleJump
    public bool canDobleJump;

    //GainedAbilities
    public bool isDobleJumpUnlocked, isHookUnlocked;

    //camera

    public bool isZoomed;
    public bool inBridge;


 


    //Rooms
    public enum Rooms
    {
        Room_1_1,

        Room_1_2,
        Room_1_2_1,
        Room_1_2_2,

        Room_1_3,
        Room_1_3_1,

        Room_1_4,
        Room_1_4_1,

        Room_1_5,
        Room_1_5_1,
        Room_1_5_2,

        Room_1_6,

        Room_1_7,


    }
    [Header("RoomTracker")]

    public Rooms currentRoom;
    public Rooms RespawnRoom;

    public void HealPlayer(int healingAmmount)
    {
        playerh.HealPlayer(healingAmmount);
    }



    /*
    Lista de cosas que tendre q retablecer:
    Gamemanager.iszoomed;
    

      
     
     */
}