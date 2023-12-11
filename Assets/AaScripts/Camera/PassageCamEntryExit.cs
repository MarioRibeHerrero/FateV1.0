using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassageCamEntryExit : MonoBehaviour
{
    [SerializeField] bool entry;
    [SerializeField] GameObject cam;
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            cam.SetActive(true);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            cam.SetActive(false);

        }
    }
}
