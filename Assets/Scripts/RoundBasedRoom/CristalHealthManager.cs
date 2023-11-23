using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CristalHealthManager : MonoBehaviour
{
    [SerializeField] int health;
    [SerializeField] GameObject parentGo;

    private RoundManager roundManager;
    private RoundEnrtyCollider entryCollider;
    private GameObject root;

    private void Start()
    {
        root = GameObject.FindAnyObjectByType<RoundManager>().gameObject;
        roundManager = GameObject.FindAnyObjectByType<RoundManager>().GetComponent<RoundManager>();
        entryCollider = GameObject.FindAnyObjectByType<RoundEnrtyCollider>().GetComponent<RoundEnrtyCollider>();
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
            roundManager.isCristalDestroyed = true;

            //PONER CUNADO SE ACABE DE VERDAD
            GameManager.Instance.inRoundRoom = false;
            root.GetComponent<Animator>().SetTrigger("OpenDoors");
            entryCollider.doorsColsed = false;
            //-----------------


            Destroy(parentGo);
        }
    }
}
