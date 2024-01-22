using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitToOpenDoorTutorial : MonoBehaviour
{
    [SerializeField] Animator anim;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerAa"))
        {
            anim.SetTrigger("OpenFast");
            GetComponent<BoxCollider>().enabled = false;
        }
    }
}
