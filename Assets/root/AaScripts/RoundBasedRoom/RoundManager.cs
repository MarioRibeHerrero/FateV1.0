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


    //cristal
    [SerializeField] GameObject cristalPrefab;


    //list of the enemies spawned
    [SerializeField] List<GameObject> normalEnemyList = new List<GameObject>();



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
        if (meleeEnemies.Length == 0) return;
        foreach (GameObject enemy in meleeEnemies)
        {
            GameObject enemyspawned = Instantiate(enemy);
            normalEnemyList.Add(enemyspawned);
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

        





    }




    public void EndRoundRoom()
    {
        Animator animator = GetComponent<Animator>();
        animator.SetTrigger("OpenDoors");
        inRoundRoom = false;
    }

    #endregion



}