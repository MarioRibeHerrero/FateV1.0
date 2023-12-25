using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEntryCollider : MonoBehaviour
{

    #region Vars
    [SerializeField] Transform pos2;
    [SerializeField] CameraManager camManager;

    [SerializeField] GameObject bossFight;
    private BossUiManager uiManager;
    private BossFightController bossFightController;
    #endregion 

    private void Awake()
    {
        uiManager = bossFight.GetComponent<BossUiManager>();
        bossFightController = bossFight.GetComponent<BossFightController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(!bossFightController.inBelzegorFight)
            {
                TpPlayerIntoBossFight(other);
                //StartBossFight
                bossFightController.StartBossFight();
            }
        }
    }


    private void TpPlayerIntoBossFight(Collider other)
    {
        //CamShit
        camManager.DisableOldCamera(GameManager.Instance.currentRoom);
        GameManager.Instance.currentRoom = GameManager.Rooms.Room_1_7;
        camManager.SetNewCamera(GameManager.Instance.currentRoom);

        //Tp player
        other.transform.position = pos2.transform.position;
        uiManager.EnableHealth();

    }


}
