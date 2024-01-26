using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundCheck : MonoBehaviour
{
    //Var clabe de isPlayerGrounded
    public bool isPlayerGrounded;
    //Posicion de la que sale el raycast
    [SerializeField] Transform groundCheckPos;
    //Layer del suelo
    [SerializeField] LayerMask groundCheckLayerMask;
    [SerializeField] float dobleJumpDistance;



    PlayerHook pHook;
    PlayerJump pJump;
    PlayerMovement pMovement;
    PlayerManager pManager;
    Rigidbody rb;


    private void Awake()
    {
        pManager = GetComponent<PlayerManager>();
        pJump = GetComponent<PlayerJump>();
        pMovement = GetComponent<PlayerMovement>();
        pHook = GetComponent<PlayerHook>();
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        //Raycast q comprueba si estas o no en el suelo(devuelve true if your on ground and false if you are not)
        if(Physics.Raycast(groundCheckPos.transform.position, Vector3.down, 0.1f, groundCheckLayerMask))
        {
            if (!isPlayerGrounded) AudioManager.Instance.PlayPlayerLand();

            isPlayerGrounded = true;
           
            //if you already used the hook, and tuch ground, you can use the hook again, and the material is updated
            if (!pHook.canHook)
            {
                pHook.canHook = true;
                pHook.HookMaterial();
                
            }
            //cantholdjump makes you not hold your jump, so when you tuch ground, 
            pJump.cantHoldJump = true;
            //when you touch ground you are no longer jumping and you can doble jump again
            pJump.isJumping = false;
            pJump.secondJump = true;
            pJump.isFalling = false;
            

            //Set hasStopedMidAir to false, so he can do it again
            pMovement.hasStopedMidAir = false;


            pHook.isFallingFromHook = false;



            if(pManager.isPlayerStunned)
            {
                rb.drag = 20; 
            }
        }
        else
        {
            isPlayerGrounded = false;
            rb.drag = 0f;
        }






        



        // PUEDES HACER EL DOBLE SALTO?
        Ray ray = new Ray(groundCheckPos.transform.position, Vector3.down);
        Debug.DrawRay(ray.origin, ray.direction * dobleJumpDistance, Color.red);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, groundCheckLayerMask))
            {
             if (hit.distance > dobleJumpDistance)
             {
                pManager.canDobleJump = true;
             }
             else
             {
                pManager.canDobleJump = false;
             }

        }
        if(hit.distance == 0) pManager.canDobleJump = true;


    }




}
