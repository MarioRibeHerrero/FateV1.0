using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEntryCollider : MonoBehaviour
{
    [SerializeField] Transform pos2;

    [SerializeField] BossUiManager uiManager;
    [SerializeField] CameraManager camManager;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            TpPlayerIntoBossFight(other);

        }
    }


    private void TpPlayerIntoBossFight(Collider other)
    {
        camManager.DisableOldCamera(GameManager.Instance.currentRoom);
        GameManager.Instance.currentRoom = GameManager.Rooms.Room_1_7;
        camManager.SetNewCamera(GameManager.Instance.currentRoom);


        GameManager.Instance.inBelzegorFight = true;
        other.transform.position = pos2.transform.position;
        uiManager.EnableHealth();
    }
}
