using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class RoundManager : MonoBehaviour
{
    #region Variables



    //spaweDifferentEnemies
    [SerializeField] GameObject meleeEnemie;
    [SerializeField] Transform[] meleeSpawnPos;
    private Transform lasPos;
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
    public bool isCristalDestroyed;


    [HideInInspector] public GameObject cristal;


    #endregion





    #region SpawnManager
    private void Start()
    {
        CreateEnemyPool();
    }



    public void CreateEnemyPool()
    {
        //instantiate and desactivar enemies

        for (int i = 0; i < 4; i++)
        {
            Debug.Log("GHOLA");
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
            currentEnemy.GetComponent<MeleeEnemyState>().CallReset();
            currentEnemy.transform.position = meleeSpawnPos[random].position;
            currentEnemy.GetComponent<Animator>().SetTrigger("Entry");

            //add it to the list so we know when to pass round
            roundRoomEnemies.Add(currentEnemy);

        }




        //cristal

        switch (newRound)
        {


            case 1:
                Debug.Log("KEK0");

                isCristalDestroyed = true;
                break;
            case 2:
                Debug.Log("KEK1");

                cristal.SetActive(true);
                cristal.transform.position = cristalPosRound2.position;
                cristal.GetComponent<RoundCristal>().Reset();
                isCristalDestroyed = false;
                break;

            case 3:
                Debug.Log("KEK2");

                cristal.SetActive(true);
                cristal.transform.position = cristalPosRound3.position;
                cristal.GetComponent<RoundCristal>().Reset();
                isCristalDestroyed = false;
                break;
        }

        





    }




    public void EndRoundRoom()
    {
        Animator animator = GetComponent<Animator>();
        animator.SetTrigger("OpenDoors");
        inRoundRoom = false;
    }

    #endregion



}