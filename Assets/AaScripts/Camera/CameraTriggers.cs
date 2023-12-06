using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTriggers : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera cam;

    private CinemachineTransposer transposer;
    private CinemachineConfiner2D confiner;

    [SerializeField] GameObject[] confiners;

    private enum CameraZone
    {
        EntryRoundRoom,
        ExitRoundRoom,

    }
    [SerializeField] CameraZone zone;


    private void Awake()
    {
        transposer = cam.GetCinemachineComponent<CinemachineTransposer>();
        confiner = cam.GetComponent<CinemachineConfiner2D>();
    }
    private void OnTriggerEnter(Collider other)
    {

        if(other.CompareTag("Player")) ChangeCameraOnEntry();

    }

    private void ChangeCameraOnEntry()
    {
        switch(zone)
        {


            case CameraZone.EntryRoundRoom:


                transposer.m_FollowOffset = new Vector3(0,2,-20);
                confiner.m_BoundingShape2D = confiners[1].GetComponent<PolygonCollider2D>();

                break;

            case CameraZone.ExitRoundRoom:
                transposer.m_FollowOffset = new Vector3(0, 2, -10);
                confiner.m_BoundingShape2D = confiners[0].GetComponent<PolygonCollider2D>();

                break;
        }
    }
}
