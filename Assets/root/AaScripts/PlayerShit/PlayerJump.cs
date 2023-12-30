using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJump : MonoBehaviour
{
    //Components
    PlayerInput playerInput;
    Rigidbody rb;
    PlayerGroundCheck pGroundCheck;
    PlayerHook pHook;

    //local
    [SerializeField] float jumpForce, maxJumpValue;
    [SerializeField] bool holdingJumpButton;
    public bool isHoldingJump;
    float maxJump;


    //secondJump
    [SerializeField] float secondJumpForce;
    public bool secondJump;
    [SerializeField] GameObject wings;

    //not so local
    public bool isJumping;
    public bool cantHoldJump;

    //CoyoteJump
    [SerializeField] float coyoteTime;
    float coyoteTimer;
    public bool isCoyoteJumping;
    //Jump Buffer
    [SerializeField] float jumpBufferTime;
    [SerializeField] float jumpBufferTimer;
    public bool isBufferJumping;


    private void Awake()
    {
        //Get Components
        playerInput = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody>();
        pGroundCheck = GetComponent<PlayerGroundCheck>();
        pHook = GetComponent<PlayerHook>();

        //Player Input Shit 
        playerInput.actions["Jump"].started += Jump_Started;
        playerInput.actions["Jump"].canceled += Jump_canceled;
    }
    void Start()
    {


        cantHoldJump = true;
        secondJump = true;

    }

    private void Jump_canceled(InputAction.CallbackContext obj)
    {
        holdingJumpButton = false;
        isHoldingJump = false;
        maxJump = 0;
    }
    private void Jump_Started(InputAction.CallbackContext obj)
    {
        
        holdingJumpButton = true;

        //si saltas, y el cotote timer es mayor que cero signifdica q estas en  el suelo.
        if (coyoteTimer > 0)
        {
            isHoldingJump = true;
            maxJump = maxJumpValue;
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        }

        //si estas en el aire, no puedes hacer el doble jump y le das al salto, entras en el jumpbuffer.
        if (!secondJump || !GameManager.Instance.isDobleJumpUnlocked || !GameManager.Instance.canDobleJump) isBufferJumping = true;





        //  DOBLE SALTO
        //si estas saltando, y aun tienees el doble salto, y lo teines desblockeado, saltas.
        if (isJumping && secondJump && GameManager.Instance.isDobleJumpUnlocked && GameManager.Instance.canDobleJump)
        {
          
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            rb.velocity = new Vector3(rb.velocity.x, jumpForce * 5, rb.velocity.z);
            secondJump = false;
            StartCoroutine(WingsToTrue());
        }

    }
    private IEnumerator WingsToTrue()
    {
        wings.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        wings.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameManager.Instance.canPlayerMove)
        {
            maxJump -= Time.deltaTime;
            Jump();
            CoyoteTimer();
            JumpBuffering();
        }


        if (!pHook.isHooking && !pGroundCheck.isPlayerGrounded && Mathf.Approximately(playerInput.actions["Movement"].ReadValue<Vector2>().x, 0f))
        {
            rb.velocity = new Vector3(0f, rb.velocity.y, 0f);
        }

    }

    private void Jump()
    {

        //salto  tipico, te permite saltar mientras estes manteniendo el boton, y no hayas pasado el timepo de salto.
        if (isHoldingJump && maxJump >= 0 )
        {
            rb.drag = 0;

            //rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            rb.velocity = new Vector3(rb.velocity.x, jumpForce * 5, rb.velocity.z);
            isJumping = true;
        }



        //si has vueleto a saltar despues de ya haber saltado, tocas el suelo y el buffertimer es mayor o igual a cero, es decir que este ultimo salto ha sido x timepo antes de tocar el suelo,
        //Salta otra vez
        if (isBufferJumping && pGroundCheck.isPlayerGrounded && jumpBufferTimer >= 0) 
        {
            //si una vez has cumplido lo anterior, sigues pulsando el boton de saltar, activamos el holding jump para q vuelvas al salto normal, en caso de que no sigas pulsandolo, hace un salto
            //pequeño
            if (holdingJumpButton)
            {
                isHoldingJump = true;
                //hacemos que el valor de salto sea el mismo q el de un salto normlal
                maxJump = maxJumpValue;
                //y ponemos el jumpbuffering a false para poder usarlo otra vez.
                isBufferJumping = false;
            }


            
        }
        //en caso de que sea menor que cero, no puedes hacerlo y por lo tanto lo ponemos a false.
        if(jumpBufferTimer <= 0)
        {
            isBufferJumping = false;

        }




        //Esto no te permite mantener el aslto para saltar todo el rato
        if (rb.velocity.y <= 0 && cantHoldJump)
        {
            cantHoldJump = false;
        }
    }

    private void JumpBuffering()
    {
        if(!isBufferJumping)
        {
            jumpBufferTimer = jumpBufferTime;
        }
        else
        {
            jumpBufferTimer -= Time.deltaTime;
        }
    }

    private void CoyoteTimer()
    {
        if (isJumping) coyoteTimer = 0;

        if (pGroundCheck.isPlayerGrounded) coyoteTimer = coyoteTime;
        else coyoteTimer -= Time.deltaTime;
    }
}
