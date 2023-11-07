using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    //Components
    PlayerInput playerInput;
    Rigidbody rb;
    PlayerGroundCheck pGroundCheck;

    [SerializeField] float jumpForce;
    [SerializeField] float acceleration, airAcceleration, deceleration, airDeceleration, maxSpeed, fallMultiplier;
    [SerializeField] float gravityScale;
    public bool isJumping;


    void Start()
    {
        //Get Components
        playerInput = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody>();
        pGroundCheck = GetComponent<PlayerGroundCheck>();

        //PlayerInputShit
        playerInput.actions["Jump"].started += Jump_Started;

    }
    private Vector2 GetInputs()
    {
        Vector2 inputs;
        inputs = playerInput.actions["XMovement"].ReadValue<Vector2>();
        return inputs;
    }

    private void Jump_Started(InputAction.CallbackContext obj)
    {
        if(pGroundCheck.isPlayerGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce * 5, ForceMode.Impulse);
            isJumping = true;
        }

    }

    // Update is called once per frame
    void Update()
    {
        GravityScale();
        Movement();

        Debug.Log(rb.velocity.x);
    }

    private void GravityScale()
    {
        Vector3 gravityVector = new Vector3(0, -gravityScale, 0);
        rb.AddForce(gravityVector, ForceMode.Acceleration);
    }
    private void Movement()
    {
        //MOVEMENT

        //we set a movement speed for the grounded player and anotherone for airplayer
        if (pGroundCheck.isPlayerGrounded) rb.AddForce(new Vector2(GetInputs().x * acceleration, 0f));
        else rb.AddForce(new Vector2(GetInputs().x * airAcceleration, 0f));

        // Since addForce does not limit the speed, we need to limit it.
        if (Mathf.Abs(rb.velocity.x) > maxSpeed) rb.velocity = new Vector2(Mathf.Sign(rb.velocity.x) * maxSpeed, rb.velocity.y);

        //DRAG
        if (pGroundCheck.isPlayerGrounded)
        {
            //if the player stops moving we want the drag to be= to the deceleration.
            if (Mathf.Abs(GetInputs().x) < 0.4 && !isJumping) rb.drag = deceleration;
            else rb.drag = 0f;
        }
       
    }

}
