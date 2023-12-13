using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatueTrigger : MonoBehaviour
{
    [SerializeField] GameObject parent;

    public bool hasFallen;
    private bool canFallAgain;
    private void Start()
    {
        canFallAgain = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && canFallAgain)
        {
            parent.GetComponent<Animator>().SetTrigger("Fall");
            Invoke(nameof(hasfal), 1f);
            canFallAgain=false;
        }
    }


    private void hasfal()
    {
        hasFallen = true;
    }
}
