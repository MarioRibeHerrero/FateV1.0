using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class HitToOpenDoorTutorial : MonoBehaviour
{
    [SerializeField] Animator anim;

    public void UnlockDoor()
    {
        anim.SetTrigger("OpenSlow");

    }
}
