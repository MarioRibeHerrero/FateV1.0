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
            }
        AutoAttackCombo();



        if (GetInputs().y >= upDifference  && !GameManager.Instance.isOccupied && !GetComponent<PlayerGroundCheck>().isPlayerGrounded)
        {
            anim.SetTrigger("AaUpAir");
        }
        else if (Mathf.Abs(GetInputs().x) >= 0 && !GameManager.Instance.isOccupied && !GetComponent<PlayerGroundCheck>().isPlayerGrounded)
        {
            anim.SetTrigger("AaAir");
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
                }
                break;
            case 1:
                if (Mathf.Abs(GetInputs().x) >= 0 && GetComponent<PlayerGroundCheck>().isPlayerGrounded && !GameManager.Instance.isOccupied)
                {
                    anim.SetInteger("AaCombo", 1);

                    anim.SetTrigger("Aa");
                }
                break;
            case 2:
                if (Mathf.Abs(GetInputs().x) >= 0 && GetComponent<PlayerGroundCheck>().isPlayerGrounded && !GameManager.Instance.isOccupied)
                {
                    anim.SetInteger("AaCombo", 2);
                    anim.SetTrigger("Aa");
                }
                break;
        }
    }
    public void AddToCombo()
    {
        if(aaCombo == 2)
        {
            aaCombo = -1;
        }

        aaCombo++;
        comboTimer = comboDuration;
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
