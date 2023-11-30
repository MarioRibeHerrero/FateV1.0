using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyHealth : MonoBehaviour, IDamageable
{
    private BasicEnemyState basicManager;
    private RoundManager roundManager;
    [SerializeField] GameObject gameObjectRoot;

    private void Awake()
    {
        basicManager = gameObjectRoot.GetComponent<BasicEnemyState>();

        roundManager = GameObject.FindAnyObjectByType<RoundManager>();
        
    }
    public void TakeDamage(int damage)
    {
        basicManager.health -= damage;
        CheckHealth();
    }

    private void CheckHealth()
    {
        if (basicManager.health <= 0)
        {
            //Aqui hacer cosas de object booling

            roundManager.roundRoomEnemies.Remove(gameObjectRoot);
            if(roundManager.roundRoomEnemies.Count <= 0) roundManager.CallUpdateRound(2, 2);
            //no se usa xq ahora lo llamo con delagados desde el roundmanager
            //basicManager.Reset();
            gameObjectRoot.SetActive(false);



        }
    }
}
