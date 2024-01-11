using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.Rendering.DebugUI;

public class PlayerAa : MonoBehaviour
{
    PlayerInput playerInput;
    PlayerManager pManager;
    PlayerAnimationManager pAnim;

    private Animator anim;

    //aaCombo
    public int aaCombo;
    [SerializeField] private float comboTimer;
    [SerializeField] float comboDuration;
    // Start is called before the first frame update


    
    void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        anim = GetComponent<Animator>();
        pManager = GetComponent<PlayerManager>();
        pAnim = GetComponent<PlayerAnimationManager>();

        playerInput.actions["Aa"].started += PlayerAa_started;
    }

    private void Update()
    {
        AaComboCounter();
    }

    private Vector2 GetInputs()
    {
        //This will get the horizontal movement
        Vector2 inputs;
        inputs = playerInput.actions["XMovement"].ReadValue<Vector2>();
        return inputs;
    }

    private void PlayerAa_started(InputAction.CallbackContext obj)
    {
        AutoAttackCombo();

        if (Mathf.Abs(GetInputs().x) >= 0 && !pManager.playerInNormalAttack && !GetComponent<PlayerGroundCheck>().isPlayerGrounded)
        {
            pAnim.CallAaAir();
            pManager.playerCurrentDamage = pManager.playerDefaultDamage;
        }
    }



    private void AutoAttackCombo()
    {
        switch (aaCombo)
        {

            case 0:
                if (Mathf.Abs(GetInputs().x) >= 0 && GetComponent<PlayerGroundCheck>().isPlayerGrounded && !pManager.playerInNormalAttack)
                {
                    pAnim.ChangeAaCombo(0);
                    pAnim.CallAa();

                    pManager.playerCurrentDamage = pManager.playerDefaultDamage;
                }
                break;
            case 1:
                if (Mathf.Abs(GetInputs().x) >= 0 && GetComponent<PlayerGroundCheck>().isPlayerGrounded && !pManager.playerInNormalAttack)
                {
                    pAnim.ChangeAaCombo(1);

                    pAnim.CallAa();
                    pManager.playerCurrentDamage = pManager.playerDefaultDamage + 10;


                }
                break;
            case 2:
                if (Mathf.Abs(GetInputs().x) >= 0 && GetComponent<PlayerGroundCheck>().isPlayerGrounded && !pManager.playerInNormalAttack)
                {
                    pAnim.ChangeAaCombo(2);
                    pAnim.CallAa();
                    pManager.playerCurrentDamage = pManager.playerDefaultDamage + 30;

                }
                break;
        }
    }
    public void AddToCombo()
    {
        comboTimer = comboDuration;

        if (aaCombo == 2)
        {
            aaCombo = 0;
            return;
        }

        aaCombo++;
    }

    private void AaComboCounter()
    {

        //si el combo es mayor q 0, le restas al timer timepo para que no sea infinito, para que dure el combo, lo unico que hay que hacer es poner el timer otra vez a x
        if(aaCombo != 0)
        {
            comboTimer -= Time.deltaTime;
        }


        //si el timer es menor que 0, el combo es 0 a 0
        if(comboTimer <= 0)
        {
            aaCombo = 0;
        }
    }

}
