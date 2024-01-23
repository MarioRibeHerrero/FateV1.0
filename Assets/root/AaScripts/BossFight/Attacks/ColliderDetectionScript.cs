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
            bFController.playerPos = pos;
            bFController.playerRight = right;
        }
    }
}
