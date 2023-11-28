using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private void Awake()
    {
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

    //RoundRoom
    public bool inRoundRoom;
    public int enemiesToKill, enemiesKilled;
    public List<GameObject> roundRoomEnemies = new List<GameObject>();
}