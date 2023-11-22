using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCameraFollow : MonoBehaviour
{
    PlayerInput playerInput;

    public float moveSpeed = 5f; 
    private Vector3 centralPosition;
    public float boundarySize;

    void Start()
    {
        
        playerInput = transform.root.GetComponent<PlayerInput>();
    }

    void Update()
    {
        centralPosition = transform.root.position;
        MovePlayer();
    }

    void MovePlayer()
    {
        float horizontalInput = GetInputs().x;
        float verticalInput = GetInputs().y;

        Vector3 moveDirection = new Vector3(horizontalInput, verticalInput, 0).normalized;

        Vector3 newPosition = transform.position + moveDirection * moveSpeed * Time.deltaTime;

       
        newPosition.x = Mathf.Clamp(newPosition.x, centralPosition.x - boundarySize, centralPosition.x + boundarySize);
        newPosition.y = Mathf.Clamp(newPosition.y, centralPosition.y - boundarySize, centralPosition.y + boundarySize);

        
        if(GetInputs() != Vector2.zero)
        {
            transform.position = newPosition;
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, centralPosition, Time.deltaTime * moveSpeed);

        }
        
    }


    private Vector2 GetInputs()
    {
        return playerInput.actions["CameraLook"].ReadValue<Vector2>();
    }
}
