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
       
    }


    private void CheckHealth()
    {
        Debug.Log(health);
        if (health <= 0)
        {
            RoundRoomShit();
            Destroy(parentGo);

        }
    }



    private void RoundRoomShit()
    {
        if (GameManager.Instance.inRoundRoom)
        {



            GameManager.Instance.enemiesKilled++;
            if (GameManager.Instance.enemiesKilled >= GameManager.Instance.enemiesToKill)
            {
                int newRound = roundManager.currentRound+ 1;


                roundManager.callCorrutine(newRound, 4);

            }
        }
    }
}
