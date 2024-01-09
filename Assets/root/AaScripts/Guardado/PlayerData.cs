
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

[System.Serializable]
public class PlayerData 
{
    public float respawnPoint;



    public PlayerData (GameManager gameManager)
    {
        respawnPoint = gameManager.respawnPointF;
    }
}
