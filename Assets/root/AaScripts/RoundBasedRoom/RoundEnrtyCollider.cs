using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundEnrtyCollider : MonoBehaviour
{
    [SerializeField] Animator root;

    private RoundManager roundManager;

    private void Awake()
    {
        roundManager = GameObject.FindAnyObjectByType<RoundManager>();

    }

    private void OnTriggerEnter(Collider other)
    {
       if(other.CompareTag("Player") && !roundManager.areDoorsClosed)
        {
            StartCoroutine(CloseDoors());
        }
    }

    private IEnumerator CloseDoors()
    {
        yield return new WaitForSeconds(0.4f);
        roundManager.StartRoundRoom();
    }
}
