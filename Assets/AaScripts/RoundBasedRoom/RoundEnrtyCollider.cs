using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundEnrtyCollider : MonoBehaviour
{
    [SerializeField] Animator root;

    public bool doorsColsed;

    private RoundManager roundManager;

    private void Awake()
    {
        roundManager = GameObject.FindAnyObjectByType<RoundManager>();

    }

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
        root.SetTrigger("CloseDoors");
        StartCoroutine(roundManager.UpdateRoundState(1, 2));
        roundManager.inRoundRoom = true;

    }
}
