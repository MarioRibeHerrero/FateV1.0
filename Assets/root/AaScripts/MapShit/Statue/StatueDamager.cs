using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatueDamager : MonoBehaviour
{

    [SerializeField] GameObject parent;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player") && !parent.GetComponent<StatueTrigger>().hasFallen)
        {
            collision.gameObject.GetComponent<PlayerHit>().Kill();
        }
    }
}
