using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTriggers : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera cam;

    private bool isZoomed;


    private void Awake()
    {

    }
    private void OnTriggerEnter(Collider other)
    {

        if(other.CompareTag("Player")) ChangeCameraOnEntry();

    }

    private void ChangeCameraOnEntry()
    {
        if(!isZoomed)
        {
            cam.GetComponent<CameraFollow>().ZoomOut();
            isZoomed = true;
        }
        else
        {
            cam.GetComponent<CameraFollow>().ZoomIn();
            isZoomed = false;
        }
    }



}
