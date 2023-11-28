using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    #region Variables

    
    

    //spaweDifferentEnemies
    [SerializeField] Transform normalEnemySpawnPoint;
    [SerializeField] Transform flyingEnemySpawnPoint;
    [SerializeField] GameObject[] meleeEnemies;
    [SerializeField] GameObject[] flyingEnemies;

    //cristal
    [SerializeField] GameObject cristalPrefab;
    [SerializeField] Transform cristalSpawnPoint;
    public bool isCristalDestroyed;


    //list of the enemies spawned
    List<GameObject> normalEnemyList = new List<GameObject>();
    List<GameObject> flyingEnemyList = new List<GameObject>();



    //RoundRoom
    public int currentRound;
    public bool inRoundRoom;
    public List<GameObject> roundRoomEnemies = new List<GameObject>();
    public int enemiesToKill, enemiesKilled;




    #endregion


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





}
