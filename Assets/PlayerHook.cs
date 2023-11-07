using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerHook : MonoBehaviour
{
    //Components
    PlayerInput playerInput;
    Rigidbody rb;
    PlayerGroundCheck pGroundCheck;
    //HookShit
    [SerializeField] Material canHookM, defaultHookM;
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] int hookForce;
    bool canHook, lineRendererActive;
    GameObject currentHook;

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody>();
        pGroundCheck = GetComponent<PlayerGroundCheck>();


        lineRenderer.enabled = false;
        //PlayerInputShit
        playerInput.actions["Hook"].started += Hook_started;
    }
    private void Update()
    {
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, currentHook.transform.localPosition);
    }
    private void Hook_started(InputAction.CallbackContext obj)
    {
        if(canHook)
        {

            lineRenderer.enabled = true;
            lineRendererActive = true;
            Vector3 forceDirection = currentHook.transform.position - transform.position;
            rb.AddForce(forceDirection.normalized * hookForce, ForceMode.Impulse);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hook"))
        {
            Debug.Log("HOAL");
            currentHook = other.transform.parent.gameObject;
            other.transform.parent.GetComponent<MeshRenderer>().material = canHookM;
            canHook = true;
        }
        if (other.CompareTag("HookPoint"))
        {
            lineRendererActive = false;
            lineRenderer.enabled = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Hook"))
        {
            currentHook = null;
            other.transform.parent.GetComponent<MeshRenderer>().material = defaultHookM;
            canHook = false;
        }
    }



}
