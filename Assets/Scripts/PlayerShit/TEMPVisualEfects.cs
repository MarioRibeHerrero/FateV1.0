using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEMPVisualEfects : MonoBehaviour
{
    [SerializeField] Material yellow, defaultM;

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.isPlayerInvulnerable)
        {
            GetComponent<MeshRenderer>().material = yellow;
        }else
        {
            GetComponent<MeshRenderer>().material = defaultM;
        }
    }
}
