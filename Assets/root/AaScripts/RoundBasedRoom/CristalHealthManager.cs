using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CristalHealthManager : MonoBehaviour, IDamageable
{
    public int health;
    [SerializeField] GameObject parentGo;

    private RoundManager roundManager;
    private CristalDisolve disolve;
    private void Awake()
    {
        disolve = GetComponent<CristalDisolve>();
            roundManager = GameObject.FindAnyObjectByType<RoundManager>().GetComponent<RoundManager>();

    }


    public void TakeDamage(int damage)
    {
        health -= damage;
        CheckHealth();
    }
    public void Reset()
    {
        Debug.Log("KRKEKE");
        health = 20;
        roundManager.isCristalDestroyed = false;
        transform.localRotation = Quaternion.Euler(new Vector3(0, 90, 90));

        Invoke(nameof(ResetPos), 0.1f);
        disolve.Reset();
    }

    private void ResetPos()
    {
        transform.localRotation = Quaternion.Euler(new Vector3(0, 90, 90));

    }
    private void CheckHealth()
    {
        if (health <= 0)
        {
            roundManager.isCristalDestroyed = true;
            disolve.Disolve();
            Invoke(nameof(SetInactive), 0.9f);
        }

        if (roundManager.roundRoomEnemies.Count <= 0 && roundManager.inRoundRoom && roundManager.isCristalDestroyed)
        {


            if (roundManager.currentRound == 3)
            {
                roundManager.EndRoundRoom();

            }
            else
            {
                int newRound;
                newRound = roundManager.currentRound + 1;
                roundManager.CallUpdateRound(newRound, 2);

            }

        }


    }


    private void SetInactive()
    {
        gameObject.SetActive(false);

    }
}
    
