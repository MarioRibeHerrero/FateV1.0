using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapTrigger : MonoBehaviour
{
    [SerializeField] GameObject parent;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !parent.GetComponent<TrapAnimationEvents>().attacking)
        {
            parent.GetComponent<Animator>().SetTrigger("Attack");
        }
    }
}
