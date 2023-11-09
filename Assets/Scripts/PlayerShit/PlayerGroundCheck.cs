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
    void Update()
    {
        //Raycast q comprueba si estas o no en el suelo(devuelve true if your on ground and false if you are not)
        if(Physics.Raycast(groundCheckPos.transform.position, Vector3.down, 0.1f, groundCheckLayerMask))
        {
            isPlayerGrounded = true;
           
            //if you already used the hook, and tuch ground, you can use the hook again, and the material is updated
            if (!GetComponent<PlayerHook>().canHook)
            {
                GetComponent<PlayerHook>().canHook = true;
                GetComponent<PlayerHook>().HookMaterial();
                
            }
            //cantholdjump makes you not hold your jump, so when you tuch ground, 
            GetComponent<PlayerJump>().cantHoldJump = true;
            //when you touch ground you are no longer jumping and you can doble jump again
            GetComponent<PlayerJump>().isJumping = false;
            GetComponent<PlayerJump>().secondJump = true;

            //Set hasStopedMidAir to false, so he can do it again
            GetComponent<PlayerMovement>().hasStopedMidAir = false;
        }
        else
        {
            isPlayerGrounded = false;

        }
    }
}
