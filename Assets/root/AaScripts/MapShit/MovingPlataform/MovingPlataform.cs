using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlataform : MonoBehaviour
{

    [SerializeField] Transform pos1, pos2;

    private float moveSpeed;
    private bool movingRight;
    private void Awake()
    {
        
    }

    private void Start()
    {
        movingRight = true;
        moveSpeed = 0;
        StartMovingPlataform();
    }


    private void Update()
    {
        this.transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        CheckLimits();
    }

    private void CheckLimits()
    {
        if (transform.position.x < pos1.transform.position.x && !movingRight)
        {
            moveSpeed *= -1;
            movingRight = true;
        }

        if (transform.position.x > pos2.transform.position.x && movingRight)
        {
            moveSpeed *= -1;
            movingRight = false;
        }
    }

    private void StartMovingPlataform()
    {
        moveSpeed = 3;
        movingRight = true;

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.parent = this.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        other.transform.parent = null;

    }
}
