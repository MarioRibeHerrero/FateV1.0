using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGravity : MonoBehaviour
{
    PlayerGroundCheck pGroundCheck;
    Rigidbody rb;
    PlayerHook pHook;
    PlayerManager pManager;
    [SerializeField] float gravityScale;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        pHook = GetComponent<PlayerHook>();
        pGroundCheck = GetComponent<PlayerGroundCheck>();
        pManager = GetComponent<PlayerManager>();
    }

    private void FixedUpdate()
    {
        if (!pHook.isHooking)
        {
            GravityScale();
        }
    }
    private void GravityScale()
    {
        //Apply gravity
        Vector3 gravityVector = new Vector3(0, -gravityScale, 0);
        rb.AddForce(gravityVector, ForceMode.Acceleration);
        

        //set drag to 0 when falling
        if (rb.velocity.y < 0  && !pGroundCheck.isPlayerGrounded)
        {
            rb.drag = 0f;
        }


    }
}
