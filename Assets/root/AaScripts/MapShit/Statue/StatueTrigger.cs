using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatueTrigger : MonoBehaviour
{
    [SerializeField] GameObject parent;

    public bool hasFallen;
    private bool canFallAgain;


    [SerializeField] bool range;
    private void Start()
    {
        canFallAgain = true;
    }
    private void OnTriggerEnter(Collider other)
    {

        if (range)
        {
            if (other.CompareTag("Player") && !hasFallen)
            {
                parent.GetComponent<Animator>().SetBool("PlayerClose", true);

            }
        }
        else
        {
            if (other.CompareTag("Player") && canFallAgain)
            {
                parent.GetComponent<Animator>().SetTrigger("Fall");
                Invoke(nameof(HasFallen), 1f);
                canFallAgain = false;
            }
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (range)
        {
            if (other.CompareTag("Player") && !hasFallen)
            {
                parent.GetComponent<Animator>().SetBool("PlayerClose", false);

            }
        }
    }

    private void HasFallen()
    {
        hasFallen = true;
    }
}
