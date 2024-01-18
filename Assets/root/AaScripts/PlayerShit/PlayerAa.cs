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
    [SerializeField] private float comboTimer;
    [SerializeField] float comboDuration;
    // Start is called before the first frame update




    //Round of 2 Aa

    public bool goToSecondAaCheck;
    public bool goToFirstAaCheck;

    private bool goToThirdAttack;

    void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        anim = GetComponent<Animator>();
        pManager = GetComponent<PlayerManager>();
        pAnim = GetComponent<PlayerAnimationManager>();

        playerInput.actions["Aa"].started += PlayerAa_started;
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
        if(GetComponent<PlayerGroundCheck>().isPlayerGrounded)AutoAttackCombo();

        if (Mathf.Abs(GetInputs().x) >= 0 && !pManager.playerInNormalAttack && !GetComponent<PlayerGroundCheck>().isPlayerGrounded)
        {
            pAnim.CallAaAir();
            pManager.playerCurrentDamage = pManager.playerDefaultDamage;
        }
    }


    
    private void AutoAttackCombo()
    {
        if(!pManager.playerInNormalAttack) pAnim.CallAa();

        if (goToSecondAaCheck)
        {
            pAnim.SetGoingToSecondAttack();
        }

        if (goToFirstAaCheck)
        {
            pAnim.SetGoingToFirstAttack();
            if (!goToThirdAttack)
            {
                goToThirdAttack = true;
                return;
            }

            pAnim.SetGoingToThirdAttack();

        }

    }


}
