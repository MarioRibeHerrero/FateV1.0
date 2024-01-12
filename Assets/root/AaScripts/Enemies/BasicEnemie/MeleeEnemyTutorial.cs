using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyTutorial : MonoBehaviour
{

    [SerializeField] MeleeEnemyStateController enemy;
    [SerializeField] MeleeEnemyState state;



    [SerializeField] GameObject textTutorial;


    private bool tutDone;
    private void Update()
    {
        if (enemy.inRangeOfAttack && !tutDone)
        {
            textTutorial.SetActive(true);
            Time.timeScale = 0.6f;
        }

        if(state.state == MeleeEnemyState.MeleeEnemyStateEnum.Stunned)
        {
            ResumeTimeScale();
        }
    }


    public void ResumeTimeScale()
    {
        Debug.Log("aSDJONASOD");
        Time.timeScale = 1f;
        tutDone = true;
    }
}
