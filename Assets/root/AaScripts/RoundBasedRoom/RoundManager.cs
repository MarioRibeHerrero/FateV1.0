using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Accessibility;
using UnityEngine.UIElements;

public class RoundManager : MonoBehaviour
{
    #region Variables

    private PlayerHealth phealth;

    //spaweDifferentEnemies
    [SerializeField] GameObject meleeEnemie;
    [SerializeField] Transform[] meleeSpawnPos;
    [SerializeField] List<Transform> usedPositions = new List<Transform>();



    //cristal
    [SerializeField] GameObject cristalPrefab;
    [SerializeField] Transform cristalPosRound2, cristalPosRound3;


    //list of the enemies spawned
    [SerializeField] List<GameObject> normalEnemyList = new List<GameObject>();



    //RoundRoom
    public int currentRound;
    public bool inRoundRoom;
    public List<GameObject> roundRoomEnemies = new List<GameObject>();
    public bool isCristalDestroyed, areDoorsClosed;


    [HideInInspector] public GameObject cristal;


    #endregion


    public void StartRoundRoom()
    {
        phealth.onPlayerDeath += ResetRoundRoom;
        areDoorsClosed = true;
        GetComponent<Animator>().SetTrigger("CloseDoors");
        CallUpdateRound(1, 2);
        inRoundRoom = true;
    }

    public void EndRoundRoom()
    {
        phealth.onPlayerDeath -= ResetRoundRoom;
        Animator animator = GetComponent<Animator>();
        animator.SetTrigger("OpenDoors");
        inRoundRoom = false;
    }

    #region RoomReset
    public void ResetRoundRoom()
    {
        //ResetearLaRoom
        inRoundRoom = false;
        GetComponent<Animator>().SetTrigger("OpenDoors");
        areDoorsClosed = false;

        ResetEnemies();
        ResetCristal();
    }

    private void ResetCristal()
    {
        if (!isCristalDestroyed)
        {
            cristal.SetActive(false);
            cristal.GetComponent<RoundCristal>().Reset();
        }
    }
    private void ResetEnemies()
    {
        //instantiate and desactivar enemies

            if (roundRoomEnemies.Count == 0) return;

            foreach (GameObject enemy in roundRoomEnemies.ToArray())
            {
                // Check if the enemy object is not null
                if (enemy != null)
                {
                    BasicEnemyHealth basicEnemyHealth = enemy.GetComponent<BasicEnemyHealth>();

                    // Check and apply damage to BasicEnemyHealth
                    if (basicEnemyHealth != null)
                    {
                        basicEnemyHealth.TakeDamage(1000);
                    }

                }
            }
        




    }

    #endregion

    #region SpawnManager
    private void Awake()
    {
        phealth = GameObject.FindAnyObjectByType<PlayerHealth>();
    }
    private void Start()
    {
        CreateEnemyPool();
    }



    public void CreateEnemyPool()
    {
        //instantiate and desactivar enemies

        for (int i = 0; i < 4; i++)
        {
            GameObject enemyspawned = Instantiate(meleeEnemie);
            normalEnemyList.Add(enemyspawned);
            enemyspawned.SetActive(false);
        }

        cristal = Instantiate(cristalPrefab);
        cristal.SetActive(false);

    }




    public void CallUpdateRound(int newRound, float waitTime)
    {
        StartCoroutine(UpdateRoundState(newRound, waitTime));
    }
    private IEnumerator UpdateRoundState(int newRound, float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        currentRound = newRound;
        usedPositions.Clear();


        //normalEnemySpawner
        for (int i = 0; i < newRound + 1; i++)
        {
            GameObject currentEnemy;

            int random;



            //random = Random.Range(0, meleeSpawnPos.Length);

            do
            {
                random = Random.Range(0, meleeSpawnPos.Length);
            } while (usedPositions.Contains(meleeSpawnPos[random]));

            usedPositions.Add(meleeSpawnPos[random]);




            //we spawn it
            do
            {
                currentEnemy = normalEnemyList[Random.Range(0, normalEnemyList.Count)];
            } while (currentEnemy.activeSelf);

            //we reset it
            currentEnemy.SetActive(true);
            currentEnemy.transform.position = meleeSpawnPos[random].position;
            currentEnemy.GetComponent<MeleeEnemyState>().CallReset();
            currentEnemy.GetComponent<Animator>().SetTrigger("Entry");

            //add it to the list so we know when to pass round
            roundRoomEnemies.Add(currentEnemy);

        }
        //Cristal
        switch (newRound)
        {
            case 1:
                isCristalDestroyed = true;
                break;
            case 2:
                cristal.SetActive(true);
                cristal.transform.position = cristalPosRound2.position;
                cristal.GetComponent<RoundCristal>().Reset();
                isCristalDestroyed = false;
                break;

            case 3:
                cristal.SetActive(true);
                cristal.transform.position = cristalPosRound3.position;
                cristal.GetComponent<RoundCristal>().Reset();
                isCristalDestroyed = false;
                break;
        }
    }






    #endregion



}