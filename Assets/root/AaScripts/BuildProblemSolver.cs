using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildProblemSolver : MonoBehaviour
{
    [SerializeField] PlayerHit pHit;


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F12))
        {
            //Morir
            pHit.HitPlayer(this.transform.position, 0, 0,10000, false);
        }
        if (Input.GetKeyDown(KeyCode.F11))
        {
            //Hit
            pHit.HitPlayer(this.transform.position, 0, 0, 0, false);
        }
        if (Input.GetKeyDown(KeyCode.F10))
        {
            //Quit Game
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.F9))
        {
            //GodMode
            GameManager.Instance.godMode = true;
        }
        if (Input.GetKeyDown(KeyCode.F8))
        {
            //GodMode
            GameObject.FindObjectOfType<BossFightController>().GetRandomBossAttack();
        }
    }
}
