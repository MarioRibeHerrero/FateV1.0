using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCollider : MonoBehaviour
{

    [SerializeField] CinemachineVirtualCamera bridgeCam;




    private void OnTriggerEnter(Collider other)
    {
        bridgeCam.Priority = 100;   
    }
    private void OnTriggerExit(Collider other)
    {
        bridgeCam.Priority = 0;
    }


}
