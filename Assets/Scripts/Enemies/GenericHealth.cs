using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericHealth : MonoBehaviour
{
    [SerializeField] int health;
    [SerializeField] GameObject parentGo;

    private RoundManager roundManager;

    private void Start()
    {
        roundManager = GameObject.FindAnyObjectByType<RoundManager>().GetComponent<RoundManager>();
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        CheckHealth();
      //  Debug.Log("GOLE");
    }


    private void CheckHealth()
    {
        if(health <= 0)
        {
            RoundRoomShit();
            Destroy(parentGo);

        }
    }



    private void RoundRoomShit()
    {
        if (GameManager.Instance.inRoundRoom && GameManager.Instance.enemiesKilled >= GameManager.Instance.enemiesToKill)
        {
            StartCoroutine(roundManager.UpdateRoundState(roundManager.currentRound++, 4));
        }
    }
}
