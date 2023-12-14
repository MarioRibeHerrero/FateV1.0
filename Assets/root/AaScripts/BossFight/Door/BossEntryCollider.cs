using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEntryCollider : MonoBehaviour
{
    [SerializeField] BossFightController bFController;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(!bFController.bossFightFinished) transform.parent.GetComponent<Animator>().SetTrigger("Close");

        }
    }
}
