using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class PlayerHook : MonoBehaviour
{
    //Components
    PlayerInput playerInput;
    Rigidbody rb;
    PlayerGroundCheck pGroundCheck;
    //HookShit
    [SerializeField] Material canHookM, defaultHookM, hookCdM;
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] int hookForce;
    bool canHook;


    public bool isHooking;
    GameObject currentHook;

    //la hacemos publica para poder modificarla desde el playerJump
    public bool canHookAgain;

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody>();
        pGroundCheck = GetComponent<PlayerGroundCheck>();


        lineRenderer.enabled = false;
        //PlayerInputShit
        playerInput.actions["Hook"].started += Hook_started;
    }


    public void HookMaterial()
    {
        if(currentHook != null)
        {
            if (canHook)
            {
                currentHook.GetComponent<MeshRenderer>().material = canHookM;

                if (!canHookAgain) currentHook.GetComponent<MeshRenderer>().material = hookCdM;
            }
            else currentHook.GetComponent<MeshRenderer>().material = defaultHookM;
        }

    }
    private void Update()
    {
        if (currentHook!= null)
        {
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, currentHook.transform.localPosition);
        }

    }
    private void Hook_started(InputAction.CallbackContext obj)
    {
        if(canHook )
        {
            
            rb.velocity = Vector3.zero;
            lineRenderer.enabled = true;
            Vector3 forceDirection = currentHook.transform.position - transform.position;
            rb.AddForce(forceDirection.normalized * hookForce, ForceMode.Impulse);

            rb.drag = 0f;
            isHooking = true;
            canHookAgain = false;
            HookMaterial();



        }
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hook"))
        {
            currentHook = other.transform.parent.gameObject;
            canHook = true;

            HookMaterial();
            //si estas grounded y buelves a entrar en la zona de hook, lo puedes usar otra vez.
            // other.transform.parent.GetComponent<MeshRenderer>().material = canHookM;
        }
        if (other.CompareTag("HookPoint"))
        {
            lineRenderer.enabled = false;
            isHooking = false;
        }


    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Hook"))
        {
            canHook = false;
            HookMaterial();
        }

        if (other.CompareTag("HookPoint"))
        {
            lineRenderer.enabled = false;
            isHooking = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (isHooking && !collision.gameObject.CompareTag("Hook") && !collision.gameObject.CompareTag("HookPoint"))
        {
            Debug.Log(collision.gameObject.name);
            rb.velocity = Vector3.zero;
            lineRenderer.enabled = false;
            isHooking = false;
        }
    }



}
