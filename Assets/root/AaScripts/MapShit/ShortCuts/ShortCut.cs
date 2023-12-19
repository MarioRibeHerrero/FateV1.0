using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortCut : MonoBehaviour
{

    [SerializeField] GameObject plataform;
    public void UnlockPath()
    {
        plataform.SetActive(false);
    }
}
