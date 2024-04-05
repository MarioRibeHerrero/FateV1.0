using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDetectionScript : MonoBehaviour
{
    [SerializeField] BossFightController bFController;


    [SerializeField] int pos;
    [SerializeField] bool right;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            bFController.playerPos =2;
            bFController.playerRight = right;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            bFController.playerPos = 1;
        }
    }
}
