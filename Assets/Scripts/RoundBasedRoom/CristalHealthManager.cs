using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CristalHealthManager : MonoBehaviour
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


        if (health <= 0)
        {
            Destroy(parentGo);
        }
    }
}
