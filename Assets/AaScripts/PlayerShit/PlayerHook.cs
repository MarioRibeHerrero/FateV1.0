using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class PlayerHook : MonoBehaviour
{
    //Components in Player
    PlayerInput playerInput;
    Rigidbody rb;
    PlayerJump pJump;
    //HookShit
    [SerializeField] Material canHookM, defaultHookM, hookCdM;
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] int hookForce;
    private bool inRangeOfHook;
    private GameObject currentHook;
    //las hacemos publica para poder modificarla desde el playerJump
    public bool canHook;
    public bool isHooking;


    private void Awake()
    {
        //components
        playerInput = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody>();
        pJump = GetComponent<PlayerJump>();
        //PlayerInputShit
        playerInput.actions["Hook"].started += Hook_started;
    }

    private void Start()
    {


        //line renderer for hhok
        lineRenderer.enabled = false;


        //we want to set canHook to true at the start, so the player can hook
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
            //the player cant jump or secondJump after using hook
            pJump.isJumping = true;
            pJump.secondJump = false;
            //Set vel to 0 so its always same force
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
        }
    }
    private void CanHookToFalse()
    {
        canHook = false;
        HookMaterial();
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hook"))
        {
            //we set the currentHook to the hook we can interact with
            currentHook = other.transform.parent.gameObject;
            inRangeOfHook = true;

            //We call method so the hooks updates its material to "canInteract"
            HookMaterial();
            
        }
        if (other.CompareTag("HookPoint"))
        {
            //when you hit the hook itself, the hook boost is over
            lineRenderer.enabled = false;
            isHooking = false;
        }


    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Hook"))
        {

            //We call method so the hooks updates its material to "can not interact"
            inRangeOfHook = false;
            HookMaterial();
        }

        if (other.CompareTag("HookPoint"))
        {
            //esta esta por si le das al gancho cuando ya estas dentro del hook, por lo que no entrarias, solo saldiras
            lineRenderer.enabled = false;
            isHooking = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        //if you coliide with anything thta is not the hook or the hook point
        if (isHooking && !collision.gameObject.CompareTag("Hook") && !collision.gameObject.CompareTag("HookPoint"))
        {
           //if hook is canceled you set vel to 0, and set everithyng that we have with the hook to false
            rb.velocity = Vector3.zero;
            lineRenderer.enabled = false;
            isHooking = false;
        }
    }



}
