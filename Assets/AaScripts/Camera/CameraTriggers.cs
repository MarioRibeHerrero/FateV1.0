using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTriggers : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera cam;


    private void Awake()
    {

    }
    private void OnTriggerEnter(Collider other)
    {

        if(other.CompareTag("Player")) ChangeCameraOnEntry();

    }

    private void ChangeCameraOnEntry()
    {
        if(!GameManager.Instance.isZoomed)
        {
            cam.GetComponent<CameraFollow>().ZoomOut();
            GameManager.Instance.isZoomed = true;
        }
        else
        {
            cam.GetComponent<CameraFollow>().ZoomIn();
            GameManager.Instance.isZoomed = false;
        }
    }



}
