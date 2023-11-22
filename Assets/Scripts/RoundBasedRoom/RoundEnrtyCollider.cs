using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundEnrtyCollider : MonoBehaviour
{
    [SerializeField] GameObject root;

    private bool doorsColsed;

    private void OnTriggerEnter(Collider other)
    {
       if(other.CompareTag("Player") && !doorsColsed)
        {
            StartCoroutine(CloseDoors());
        }
    }

    private IEnumerator CloseDoors()
    {

        yield return new WaitForSeconds(0.4f);
        doorsColsed = true;
        root.GetComponent<Animator>().SetTrigger("CloseDoors");

    }
}
