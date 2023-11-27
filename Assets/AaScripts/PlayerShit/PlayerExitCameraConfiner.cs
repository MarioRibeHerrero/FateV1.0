using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExitCameraConfiner : MonoBehaviour
{

    [SerializeField] CinemachineVirtualCamera cam;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CameraConfiner"))
        {
            
            GameObject player = GameObject.FindAnyObjectByType<PlayerCameraFollow>().gameObject;
            cam.LookAt = player.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("CameraConfiner"))
        {
            cam.LookAt = null;
        }
    }
}
