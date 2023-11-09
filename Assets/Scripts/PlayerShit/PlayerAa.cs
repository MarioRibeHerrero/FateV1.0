using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAa : MonoBehaviour
{
    PlayerInput playerInput;

    [SerializeField] float upDifference;

    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        anim = GetComponent<Animator>();

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
        if (GetInputs().y >= upDifference && GetComponent<PlayerGroundCheck>().isPlayerGrounded)
        {
            anim.SetTrigger("AaUp");
        }else if(Mathf.Abs(GetInputs().x) >= 0 && GetComponent<PlayerGroundCheck>().isPlayerGrounded)
        {
            anim.SetTrigger("Aa");
        }

    }

}
