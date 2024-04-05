using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpFades : MonoBehaviour
{
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        anim.SetTrigger("Enter");
        
    }

    private void Disable()
    {
        
        gameObject.SetActive(false);
    }
}
