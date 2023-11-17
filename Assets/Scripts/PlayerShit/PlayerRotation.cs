using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRotation : MonoBehaviour
{

    //PlayerComponets
    PlayerInput playerInput;
    [SerializeField] private GameObject playerBody;
    //
    public bool isFacingRight;

    void Start()
    {
        //PlayerComponents
        playerInput = GetComponent<PlayerInput>();

        //vars
        isFacingRight = true;


    }

    // Update is called once per frame
    void Update()
    {
        GetRotation();
        if (GameManager.Instance.canPlayerRotate) SetRotation();

    }

    private void SetRotation()
    {
        if (isFacingRight)
        {
            playerBody.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            playerBody.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
    private void GetRotation()
    {
        if(GetInputs().x > 0)
        {
            isFacingRight = true;
        }

        if (GetInputs().x < 0)
        {
            isFacingRight = false;
        }

    }
    private Vector2 GetInputs()
    {
        //This will get the horizontal movement
        Vector2 inputs;
        inputs = playerInput.actions["XMovement"].ReadValue<Vector2>();
        return inputs;
    }
}
