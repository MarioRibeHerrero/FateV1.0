using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class GenericHealth : MonoBehaviour, IDamageable, IKilleable, IHealPlayer
{
    [SerializeField] int health;
    [SerializeField] GameObject parentGo;
    [SerializeField] bool wantToRespawn;

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
       
    }


    public void CheckHealth()
    {
       
        if (health <= 0)
        {
            RoundRoomShit();
            Destroy(parentGo);

        }
    }



    private void RoundRoomShit()
    {
        if (roundManager.inRoundRoom)
        {

            

            if (roundManager.roundRoomEnemies.Count > 0)
            {
                

                string prefabName = (this.transform.parent?.name ?? this.transform.name).Replace("(Clone)", "");


                
                GameObject originalPrefab = roundManager.roundRoomEnemies.Find(obj => obj.name == prefabName);
                
                
                if (originalPrefab != null && roundManager.roundRoomEnemies.Contains(originalPrefab))
                {
                    roundManager.roundRoomEnemies.Remove(originalPrefab);

                }

                //RESPAWN
                if (!roundManager.isCristalDestroyed && roundManager.currentRound == 3 && wantToRespawn)
                {


                    roundManager.RespawnEnemyCT(1, originalPrefab);
                }


            }


            if (roundManager.roundRoomEnemies.Count == 0)
            {
                if (roundManager.currentRound != 3)
                {
                    int newRound = roundManager.currentRound + 1;
                    roundManager.callCorrutine(newRound, 4);
                }
                else if(roundManager.isCristalDestroyed)
                {
                    //PONER CUNADO SE ACABE DE VERDAD
                    roundManager.inRoundRoom = false;
                    root.GetComponent<Animator>().SetTrigger("OpenDoors");
                    entryCollider.doorsColsed = false;
                    //-----------------
                }

            }


            //Respawn




        }
    }



}
