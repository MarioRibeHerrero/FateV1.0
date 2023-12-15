using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEntryCollider : MonoBehaviour
{
    [SerializeField] Transform pos2;

    [SerializeField] BossUiManager uiManager;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            TpPlayerIntoBossFight(other);

        }
    }


    private void TpPlayerIntoBossFight(Collider other)
    {

        GameManager.Instance.inBelzegorFight = true;
        other.transform.position = pos2.transform.position;
        uiManager.EnableHealth();
    }
}
