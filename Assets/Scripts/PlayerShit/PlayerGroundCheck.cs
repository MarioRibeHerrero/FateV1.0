using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundCheck : MonoBehaviour
{
    public bool isPlayerGrounded;
    [SerializeField] Transform groundCheckPos;
    [SerializeField] LayerMask groundCheckLayerMask;
    void Update()
    {
        if(Physics.Raycast(groundCheckPos.transform.position, Vector3.down, 0.05f, groundCheckLayerMask))
        {
            isPlayerGrounded = true;
           
            //Puede hookear otra vez y actualizamos los materiales
            if (!GetComponent<PlayerHook>().canHook)
            {
                GetComponent<PlayerHook>().canHook = true;
                GetComponent<PlayerHook>().HookMaterial();
                
            }
            GetComponent<PlayerJump>().cantHoldJump = true;
            GetComponent<PlayerJump>().isJumping = false;
            GetComponent<PlayerJump>().secondJump = true;
        }
        else
        {
            isPlayerGrounded = false;

        }
    }
}
