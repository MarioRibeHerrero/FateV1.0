using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBridgeMovement : MonoBehaviour
{
    //Components of Player
    PlayerInput playerInput;
    Rigidbody rb;


    //Movement variables
    [SerializeField] float acceleration, deceleration, maxSpeed;
     bool changingDirection;


    private void Awake()
    {
        //Get Components
        playerInput = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody>();
    }

    private Vector2 GetInputsX()
    {
        //This will get the horizontal movement
        Vector2 inputs;
        inputs = playerInput.actions["XMovement"].ReadValue<Vector2>();
        return inputs;
    }



    private void FixedUpdate()
    {
        if (GameManager.Instance.canPlayerMove)
        {
            Movement();
        }
    }


    private void Movement()
    {
        //check if you are changing direcction
        changingDirection = ((rb.velocity.x < 0 && GetInputsX().y > 0) || (rb.velocity.x > 0 && GetInputsX().y < 0));

        Debug.Log(GetInputsX().y);
        //we set a movement aceleration for the grounded player and anotherone for airplayer
        rb.AddForce(new Vector2(-GetInputsX().y * acceleration, 0f));
        

        // Since addForce does not limit the speed, we need to limit it.
        if (Mathf.Abs(rb.velocity.x) > maxSpeed) rb.velocity = new Vector2(Mathf.Sign(rb.velocity.x) * maxSpeed, rb.velocity.x);


        //DRAG
        if ((Mathf.Abs(GetInputsX().y) < 0.4) || changingDirection) rb.drag = deceleration;
        else rb.drag = 0f;




    }
}  
