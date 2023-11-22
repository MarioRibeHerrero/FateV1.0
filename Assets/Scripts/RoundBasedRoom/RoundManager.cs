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

    public IEnumerator UpdateRoundState(int newRound, float waitTime)
    {
        currentRound = newRound;
        yield return new WaitForSeconds(waitTime);
        switch(newRound)
        {
            case 0:
                break;
            case 1:
                
                for(int i = 0; i < newRound+1; i++)
                {
                    GameObject currentEnemy = meleeEnemies[Random.Range(0, meleeEnemies.Length)];
                    if (currentEnemy != lastEnemy || lastEnemy == null)
                    {
                        Instantiate(currentEnemy);
                        lastEnemy = currentEnemy;
                        //
                        GameManager.Instance.enemiesKilled = 0;
                        GameManager.Instance.enemiesToKill = newRound+1;
                    }
                    else
                    {
                        i--;
                        break;
                    }
                }

                break;
            case 2:

                break;
            case 3:

                break;


        }
    }
}
