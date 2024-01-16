using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OntriggerEnterEnableGo : MonoBehaviour
{
    [SerializeField] GameObject go;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")) go.SetActive(true);
    }
}
