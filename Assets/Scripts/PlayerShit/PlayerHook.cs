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
    bool inRangeOfHook;
    //la hacemos publica para poder modificarla desde el playerJump
    public bool canHook;
    public bool isHooking;
    GameObject currentHook;



    private void Start()
    {
        //components
        playerInput = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody>();
        pGroundCheck = GetComponent<PlayerGroundCheck>();

        //line renderer for hhok
        lineRenderer.enabled = false;
        //PlayerInputShit
        playerInput.actions["Hook"].started += Hook_started;
        canHook = true;
    }


    public void HookMaterial()
    {
        //define el color de si el hook puede ser cogido o no(visual)
        if(currentHook != null)
        {
            if (inRangeOfHook)
            {
                currentHook.GetComponent<MeshRenderer>().material = canHookM;

                if (!canHook) currentHook.GetComponent<MeshRenderer>().material = hookCdM;
            }
            else currentHook.GetComponent<MeshRenderer>().material = defaultHookM;
        }

    }
    private void Update()
    {
        SetLineRedererPositions();
    }

    private void SetLineRedererPositions()
    {
        if (currentHook != null)
        {
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, currentHook.transform.localPosition);
        }
    }
    private void Hook_started(InputAction.CallbackContext obj)
    {
        if(inRangeOfHook && canHook)
        {
            //Set vel to 0 so its always safe force
            rb.velocity = Vector3.zero;
            //enable line renderer
            lineRenderer.enabled = true;
            //add the force to the hook
            Vector3 forceDirection = currentHook.transform.position - transform.position;
            rb.AddForce(forceDirection.normalized * hookForce, ForceMode.Impulse);
            //remove drag so the drag dosent stop you
            rb.drag = 0f;
            isHooking = true;
            Invoke("CanHookToFalse", 0.02f);
            HookMaterial();
        }
    }
    private void CanHookToFalse()
    {
        canHook = false;
        HookMaterial();
        Debug.Log("HOLA");
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hook"))
        {
            currentHook = other.transform.parent.gameObject;
            inRangeOfHook = true;

            HookMaterial();
            //si estas grounded y buelves a entrar en la zona de hook, lo puedes usar otra vez.
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
            inRangeOfHook = false;
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
