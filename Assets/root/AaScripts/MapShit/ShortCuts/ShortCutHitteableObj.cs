using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortCutHitteableObj : MonoBehaviour
{
    [SerializeField] GameObject go;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerAa"))
        {
            go.SetActive(true);
            Destroy(gameObject);
        }

    }
}
