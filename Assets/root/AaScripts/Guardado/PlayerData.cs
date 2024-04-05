
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

[System.Serializable]
public class PlayerData 
{
    public float respawnPoint;
    public float[] respawnPos;
    public bool shortCut;
    public bool dobleJump;


    public PlayerData (GameManager gameManager)
    {
        respawnPoint = gameManager.RespawnPointF;

        respawnPos = new float[3];

        respawnPos[0] = gameManager.respawnVector.x;
        respawnPos[1] = gameManager.respawnVector.y;
        respawnPos[2] = gameManager.respawnVector.z;

        shortCut = gameManager.shortCutUnlocked;

        dobleJump = gameManager.dobleJump;
    }
}
