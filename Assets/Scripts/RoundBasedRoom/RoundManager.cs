using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    public int currentRound;
    

    //spaweDifferentEnemies
    GameObject lastEnemy;
    [SerializeField] Transform normalEnemySpawnPoint;
    [SerializeField] GameObject[] meleeEnemies;


    //cristal
    [SerializeField] GameObject cristalPrefab;
    [SerializeField] Transform cristalSpawnPoint;
    public bool isCristalDestroyed;



    List<GameObject> normalEnemyList = new List<GameObject>();
    public void callCorrutine(int newRound, float waitTime)
    {
        //PRUEBA A VER SI NO HACE LA CORRUTINA XQ SE DESTRUYTE EL OBJ
        StartCoroutine(UpdateRoundState(newRound, waitTime));
    }
    public IEnumerator UpdateRoundState(int newRound, float waitTime)
    {
        normalEnemyList.Clear();
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

        }

        //FlyingEnemySpawner

        switch (currentRound)
        {
            case 0:
                
                break;
            case 1:
                //spawn2
                break;
            case 2:
                //spawn3
                break;
            case 3:
                //infinite
                break;

        }





    }

}
