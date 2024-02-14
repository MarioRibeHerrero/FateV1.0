using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [Header("Game Start Shit")]
    [SerializeField] CameraManager camManager;

    [Header("HealingShit")]
    public int parryHealingAmmount;
    public int aaHealingAmmount;



    [Header("PlayerStatus")]

    public bool playerSitting;
    public bool canPlayerMove;
    public bool canPlayerRotate;
    public bool playerInNormalAttack;
    public bool isPlayerStunned;
    public bool isPlayerInvulnerable;
    public bool isPlayerParry;
    public bool inStrongAttack;
    public bool isPlayerAlive;


    public bool repeatAa;
    public bool canGoToThirdAttack;
    public int combo;



    public bool CanDobleJump
    {
        get
        {
            return canDobleJump;
        }

        set
        {
            canDobleJump = value;
            GameManager.Instance.dobleJump = value;
        }
    }

    public bool canDobleJump;

    public int playerCurrentDamage;



    [Header("PlayerModifiableVars")]

    public float playerHealth;
    public int playerDefaultDamage;



    [Header("Unlockeable Abilities")]

    public bool isDobleJumpUnlocked;

    private void Awake()
    {
        playerCurrentDamage = playerDefaultDamage;

        //Load shit

        if (GameManager.Instance.isGameLoaded)
        {
            PlayerData data = SaveSystem.LoadGameManager();

            //FOR CAMERA
            GameManager.Instance.RespawnPointF = data.respawnPoint;
            camManager.SetNewCamera(GameManager.Instance.currentRoom);

            //Position
            GameManager.Instance.respawnVector.x = data.respawnPos[0];
            GameManager.Instance.respawnVector.y = data.respawnPos[1];
            GameManager.Instance.respawnVector.z = data.respawnPos[2];
            this.transform.position = GameManager.Instance.respawnVector;

            //ShordCut
            GameManager.Instance.shortCutUnlocked = data.shortCut;
            if (GameManager.Instance.shortCutUnlocked) GameObject.Find("HitteableObj").GetComponent<ShortCutHitteableObj>().ActivateShortCut();

            //Doble Jump
            GameManager.Instance.dobleJump = data.dobleJump;
        }
        else
        {
           this.transform.position = new Vector3(-17.21802f, -4.087304f, 4.163336e-16f);
           GameManager.Instance.RespawnPointF = 1.1f;
           camManager.SetNewCamera(GameManager.Instance.currentRoom);

        }





    }
    private void Start()
    {



        canPlayerMove = true;
        canPlayerRotate = true;
        playerInNormalAttack = false;
        isPlayerStunned = false;
        isPlayerInvulnerable = false;
        isPlayerParry = false;
        
        inStrongAttack = false;
        playerHealth = 100;
        isPlayerAlive = true;
        canDobleJump = true;
        isDobleJumpUnlocked = GameManager.Instance.dobleJump;

    }
}
