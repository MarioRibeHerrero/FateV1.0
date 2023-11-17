using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatueTrigger : MonoBehaviour
{
    [SerializeField] GameObject parent;

    public bool hasFallen;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasFallen)
        {
            parent.GetComponent<Animator>().SetTrigger("Fall");
            Invoke(nameof(hasfal), 1f);
        }
    }


    private void hasfal()
    {
        hasFallen = true;
    }
}
