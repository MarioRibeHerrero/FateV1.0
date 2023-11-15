using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGravity : MonoBehaviour
{

    Rigidbody rb;
    PlayerHook pHook;
    [SerializeField] float gravityScale;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        pHook = GetComponent<PlayerHook>();
    }
    private void FixedUpdate()
    {
        if (!pHook.isHooking && GameManager.Instance.canPlayerMove)
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
        if (rb.velocity.y <= 0 && !GameManager.Instance.isPlayerStunned) rb.drag = 0f;
    }
}
