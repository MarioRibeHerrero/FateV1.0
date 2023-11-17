using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericHealth : MonoBehaviour
{
    private int health;
    private void Start()
    {
        health = 140;
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        CheckHealth();
        Debug.Log("GOLE");
    }


    private void CheckHealth()
    {
        if(health <= 0)
        {
            Destroy(transform.root.gameObject);
        }
    }
}
