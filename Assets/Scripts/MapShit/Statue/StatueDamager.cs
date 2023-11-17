using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatueDamager : MonoBehaviour
{

    [SerializeField] GameObject parent;
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.transform.tag);
        if (collision.transform.CompareTag("Player") && !parent.GetComponent<StatueTrigger>().hasFallen)
        {
            Debug.Log("HOLA");
            collision.gameObject.GetComponent<PlayerHit>().Kill();
        }
    }
}
