using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [Header("HealingShit")]
    public int parryHealingAmmount;
    public int aaHealingAmmount;



    [Header("PlayerStatus")]

    public bool canPlayerMove;
    public bool canPlayerRotate;
    public bool playerInNormalAttack;
    public bool isPlayerStunned;
    public bool isPlayerInvulnerable;
    public bool isPlayerParry;
    public bool inStrongAttack;
    public bool isPlayerAlive;
    public bool canDobleJump;
    public int playerCurrentDamage;



    [Header("PlayerModifiableVars")]

    public float playerHealth;
    public int playerDefaultDamage;



    [Header("Unlockeable Abilities")]

    public bool isDobleJumpUnlocked;
    private void Start()
    {
        canPlayerMove = true;
        canPlayerRotate = true;
        playerInNormalAttack = false;
        isPlayerStunned = false;
        isPlayerInvulnerable = false;
        isPlayerParry = false;
        playerCurrentDamage = playerDefaultDamage;
        inStrongAttack = false;
        playerHealth = 100;
        isPlayerAlive = true;
        canDobleJump = true;


    }
}
