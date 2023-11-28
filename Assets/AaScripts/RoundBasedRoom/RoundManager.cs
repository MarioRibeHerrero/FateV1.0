using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    public int currentRound;
    

    //spaweDifferentEnemies
    [SerializeField] Transform normalEnemySpawnPoint;
    [SerializeField] Transform flyingEnemySpawnPoint;
    [SerializeField] GameObject[] meleeEnemies;
    [SerializeField] GameObject[] flyingEnemies;

    //cristal
    [SerializeField] GameObject cristalPrefab;
    [SerializeField] Transform cristalSpawnPoint;
    public bool isCristalDestroyed;



    List<GameObject> normalEnemyList = new List<GameObject>();
    List<GameObject> flyingEnemyList = new List<GameObject>();


    #region prueba

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
            GameManager.Instance.enemiesKilled = 0;
            GameManager.Instance.enemiesToKill = 100;
        }
        else
        {
            GameManager.Instance.enemiesKilled = 0;
            GameManager.Instance.enemiesToKill = newRound + 1;
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
            GameManager.Instance.roundRoomEnemies.Add(currentEnemy);

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
                    GameManager.Instance.roundRoomEnemies.Add(currentFlyingEnemy);

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
                    GameManager.Instance.roundRoomEnemies.Add(currentFlyingEnemy);

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
            GameManager.Instance.roundRoomEnemies.Add(originalPrefab);

        }
    }





}
