using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRotation : MonoBehaviour
{

    //PlayerComponets
    PlayerInput playerInput;
    PlayerManager pManager;
    [SerializeField] private GameObject playerBody;
    //
    public bool isFacingRight;


    private void Awake()
    {
        //PlayerComponents
        playerInput = GetComponent<PlayerInput>();
        pManager = GetComponent<PlayerManager>();

    }
    void Start()
    {

        //vars
        isFacingRight = true;


    }

    // Update is called once per frame
    void Update()
    {
        GetRotation();
        if (pManager.canPlayerRotate) SetRotation();

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


        if(GameManager.Instance.thirdPersonCam)
        {
            if (-GetInputs().y > 0)
            {
                isFacingRight = true;
            }

            if (-GetInputs().y < 0)
            {
                isFacingRight = false;
            }
        }

    }
    private Vector2 GetInputs()
    {
        //This will get the horizontal movement
        Vector2 inputs;
        inputs = playerInput.actions["Movement"].ReadValue<Vector2>();
        return inputs;
    }
}
