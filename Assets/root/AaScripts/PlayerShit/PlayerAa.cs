using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAa : MonoBehaviour
{
    PlayerInput playerInput;

    [SerializeField] float upDifference;

    private Animator anim;

    //aaCombo
    [SerializeField] private int aaCombo;
    [SerializeField] private float comboTimer;
    [SerializeField] float comboDuration;
    // Start is called before the first frame update


    
    void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        anim = GetComponent<Animator>();

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

            if (GetInputs().y >= upDifference && GetComponent<PlayerGroundCheck>().isPlayerGrounded && !GameManager.Instance.isOccupied)
            {
                anim.SetTrigger("AaUp");
                GameManager.Instance.playerDamage = GameManager.Instance.playerDefaultDamage;
            }
        AutoAttackCombo();



        if (GetInputs().y >= upDifference  && !GameManager.Instance.isOccupied && !GetComponent<PlayerGroundCheck>().isPlayerGrounded)
        {
            anim.SetTrigger("AaUpAir");
            GameManager.Instance.playerDamage = GameManager.Instance.playerDefaultDamage;
        }
        else if (Mathf.Abs(GetInputs().x) >= 0 && !GameManager.Instance.isOccupied && !GetComponent<PlayerGroundCheck>().isPlayerGrounded)
        {
            anim.SetTrigger("AaAir");
            GameManager.Instance.playerDamage = GameManager.Instance.playerDefaultDamage;
        }
    }



    private void AutoAttackCombo()
    {
        switch (aaCombo)
        {

            case 0:
                if (Mathf.Abs(GetInputs().x) >= 0 && GetComponent<PlayerGroundCheck>().isPlayerGrounded && !GameManager.Instance.isOccupied)
                {
                    anim.SetInteger("AaCombo", 0);
                    anim.SetTrigger("Aa");
                    GameManager.Instance.playerDamage = GameManager.Instance.playerDefaultDamage;
                }
                break;
            case 1:
                if (Mathf.Abs(GetInputs().x) >= 0 && GetComponent<PlayerGroundCheck>().isPlayerGrounded && !GameManager.Instance.isOccupied)
                {
                    anim.SetInteger("AaCombo", 1);

                    anim.SetTrigger("Aa");
                    GameManager.Instance.playerDamage = GameManager.Instance.playerDefaultDamage + 10;


                }
                break;
            case 2:
                if (Mathf.Abs(GetInputs().x) >= 0 && GetComponent<PlayerGroundCheck>().isPlayerGrounded && !GameManager.Instance.isOccupied)
                {
                    anim.SetInteger("AaCombo", 2);
                    anim.SetTrigger("Aa");
                    GameManager.Instance.playerDamage = GameManager.Instance.playerDefaultDamage + 30;

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
