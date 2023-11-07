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
        if(Physics.Raycast(groundCheckPos.transform.position, Vector3.down, 0.2f, groundCheckLayerMask))
        {
            isPlayerGrounded = true;

            //Puede hookear otra vez y actualizamos los materiales
            GetComponent<PlayerHook>().canHookAgain = true;
            GetComponent<PlayerHook>().HookMaterial();

        }
        else
        {
            isPlayerGrounded = false;
            GetComponent<PlayerJump>().isJumping = false;


        }
    }
}
