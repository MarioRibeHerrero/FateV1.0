using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prueba : MonoBehaviour
{
    [SerializeField] GameObject enmemy;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.K))
        {
            enmemy.SetActive(false);
        }
        if (Input.GetKeyUp(KeyCode.M))
        {
            enmemy.GetComponent<MeleeEnemyState>().onEnemyReset();
            enmemy.SetActive(true);

        }
    }
}
