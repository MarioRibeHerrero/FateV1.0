using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCameraOffset : MonoBehaviour
{
    private PlayerMovement pMovement;
    private CinemachineVirtualCamera cam;

    [SerializeField] float smothTime;
    private void Awake()
    {
        pMovement = GameObject.FindAnyObjectByType<PlayerMovement>();
        cam = GetComponent<CinemachineVirtualCamera>();
    }


    private void Update()
    {
        if (pMovement.inputs.x != 0 && !pMovement.transform.GetComponent<PlayerManager>().inStrongAttack && !pMovement.transform.GetComponent<PlayerManager>().playerInNormalAttack)
        {
            CinemachineTransposer t = cam.GetCinemachineComponent<CinemachineTransposer>();
            float offset = Mathf.Sin(pMovement.inputs.x ) * 2f;
            t.m_FollowOffset.x = Mathf.Lerp(t.m_FollowOffset.x, offset, Time.deltaTime * smothTime);
        }
        else
        {
            CinemachineTransposer transposer = cam.GetCinemachineComponent<CinemachineTransposer>();
            transposer.m_FollowOffset.x = Mathf.Lerp(transposer.m_FollowOffset.x, 0, Time.deltaTime * smothTime * 1f);
        }
    }

 
}
