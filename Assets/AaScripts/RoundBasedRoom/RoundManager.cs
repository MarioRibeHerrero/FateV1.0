using Autodesk.Fbx;
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
    [SerializeField] GameObject[] meleeEnemies;
    [SerializeField] GameObject[] flyingEnemies;
    [SerializeField] GameObject[] spawnPoints;


    //cristal
    [SerializeField] GameObject cristalPrefab;


    //list of the enemies spawned
    [SerializeField] List<GameObject> normalEnemyList = new List<GameObject>();
    [SerializeField] List<GameObject> flyingEnemyList = new List<GameObject>();



    //RoundRoom
    public int currentRound;
    public bool inRoundRoom;
    public List<GameObject> roundRoomEnemies = new List<GameObject>();
    public bool isCristalDestroyed;





    #endregion





    #region SpawnManager
    private void Start()
    {
        CreateEnemyPool();
    }



    public void CreateEnemyPool()
    {
        //instantiate and desactivar enemies
        if (meleeEnemies.Length == 0 && flyingEnemies.Length == 0) return;
        foreach (GameObject enemy in meleeEnemies)
        {
            GameObject enemyspawned = Instantiate(enemy);
            normalEnemyList.Add(enemyspawned);
            enemyspawned.SetActive(false);
        }

        foreach (GameObject enemy in flyingEnemies)
        {
            GameObject enemyspawned = Instantiate(enemy);
            
            flyingEnemyList.Add(enemyspawned);
            enemyspawned.SetActive(false);
        }

    }




    public void CallUpdateRound(int newRound, float waitTime)
    {

        StartCoroutine(UpdateRoundState(newRound, waitTime));
    }

    private IEnumerator UpdateRoundState(int newRound, float waitTime)
    {
        


        yield return new WaitForSeconds(waitTime);
        currentRound = newRound;
        Debug.Log(currentRound);
        if (currentRound == 3)
        {
            Instantiate(cristalPrefab);
        }

        //normalEnemySpawner
        for (int i = 0; i < newRound + 1; i++)
        {
            GameObject currentEnemy;

            //we spawn it
            do
            {
                currentEnemy = normalEnemyList[Random.Range(0, normalEnemyList.Count)];
            } while (currentEnemy.activeSelf);

            //we reset it
            currentEnemy.SetActive(true);
            currentEnemy.GetComponent<MeleeEnemyState>().CallReset();
            // currentEnemy.GetComponent<IReseteable>().Reset();
            //add it to the list so we know when to pass round
            roundRoomEnemies.Add(currentEnemy);

        }

        //FlyingEnemy

        if(currentRound != 3)
        {
            for (int i = 0; i < newRound +1 ; i++)
            {
                GameObject currentEnemy;

                //we spawn it
                do
                {
                    currentEnemy = flyingEnemyList[Random.Range(0, flyingEnemyList.Count)];
                } while (currentEnemy.activeSelf);

                //we reset it
                currentEnemy.SetActive(true);
                currentEnemy.transform.GetChild(0).transform.position = spawnPoints[i].transform.position;
                currentEnemy.GetComponent<FlyingEnemyState>().onEnemyReset();
                //add it to the list so we know when to pass round
                roundRoomEnemies.Add(currentEnemy);

            }
        }else
        {
            for (int i = 0; i < newRound ; i++)
            {
                GameObject currentEnemy;

                //we spawn it
                do
                {
                    currentEnemy = flyingEnemyList[Random.Range(0, flyingEnemyList.Count)];
                } while (currentEnemy.activeSelf);

                //we reset it
                currentEnemy.SetActive(true);
                currentEnemy.transform.GetChild(0).transform.position = spawnPoints[i].transform.position;
                currentEnemy.GetComponent<FlyingEnemyState>().onEnemyReset();
                //add it to the list so we know when to pass round
                roundRoomEnemies.Add(currentEnemy);

            }
        }





    }


    public void CallRespawn(GameObject obToRespawn, Transform pos)
    {
       // obToRespawn.SetActive(true);
        obToRespawn.GetComponent<FlyingEnemyState>().onEnemyReset();
        obToRespawn.transform.position = pos.transform.position;
        // StartCoroutine(RespawnEnemy(obToRespawn, pos));
    }
    private IEnumerator RespawnEnemy(GameObject obToRespawn, Transform pos)
    {
        yield return new WaitForSeconds(3f);


    }


    public void EndRoundRoom()
    {
        Animator animator = GetComponent<Animator>();
        animator.SetTrigger("OpenDoors");
        inRoundRoom = false;
    }

    #endregion



}
#region OldMEthod
/*
public void callCorrutine(int newRound, float waitTime)
{
    //PRUEBA A VER SI NO HACE LA CORRUTINA XQ SE DESTRUYTE EL OBJ
    StartCoroutine(UpdateRoundState(newRound, waitTime));
}



public IEnumerator UpdateRoundState(int newRound, float waitTime)
{
    normalEnemyList.Clear();
    flyingEnemyList.Clear();

    currentRound = newRound;
    yield return new WaitForSeconds(waitTime);

    if(currentRound == 3)
    {
        Instantiate(cristalPrefab, cristalSpawnPoint);
        enemiesKilled = 0;
        enemiesToKill = 100;
    }
    else
    {
        enemiesKilled = 0;
        enemiesToKill = newRound + 1;
    }



    //normalEnemySpawner
    for (int i = 0; i < newRound + 1; i++)
    {
        GameObject currentEnemy;

        do
        {
            currentEnemy = meleeEnemies[Random.Range(0, meleeEnemies.Length)];
        } while (normalEnemyList.Contains(currentEnemy));

        Instantiate(currentEnemy);
        normalEnemyList.Add(currentEnemy);
        roundRoomEnemies.Add(currentEnemy);

    }

    //FlyingEnemySpawner

    switch (currentRound)
    {
        case 1:
        case 2:
            for (int i = 0; i < newRound + 1; i++)
            {
                GameObject currentFlyingEnemy;

                do
                {
                    currentFlyingEnemy = flyingEnemies[Random.Range(0, flyingEnemies.Length)];
                } while (flyingEnemyList.Contains(currentFlyingEnemy));

                Instantiate(currentFlyingEnemy);
                flyingEnemyList.Add(currentFlyingEnemy);
                roundRoomEnemies.Add(currentFlyingEnemy);

            }
            //spawn2
            break;
        case 3:

            for (int i = 0; i < newRound ; i++)
            {
                GameObject currentFlyingEnemy;

                do
                {
                    currentFlyingEnemy = flyingEnemies[Random.Range(0, flyingEnemies.Length)];
                } while (flyingEnemyList.Contains(currentFlyingEnemy));

                Instantiate(currentFlyingEnemy);
                flyingEnemyList.Add(currentFlyingEnemy);
                roundRoomEnemies.Add(currentFlyingEnemy);

            }
            //infinite


            break;

    }







}
//have to use this method, because when i destroy the othre item, the corrutine call gets canceled.
public void RespawnEnemyCT(float delay, GameObject originalPrefab)
{
    StartCoroutine(RespawnEnemy(delay, originalPrefab));
}

public IEnumerator RespawnEnemy(float delay, GameObject originalPrefab)
{
    yield return new WaitForSeconds(delay);
    Debug.Log(originalPrefab);
    if (flyingEnemyList.Contains(originalPrefab))
    {

        Instantiate(originalPrefab);
        roundRoomEnemies.Add(originalPrefab);

    }
}

*/

#endregion