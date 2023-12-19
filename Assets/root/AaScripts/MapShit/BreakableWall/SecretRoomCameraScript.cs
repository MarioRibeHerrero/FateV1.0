using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretRoomCameraScript : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] LayerMask kek;
    private void OnEnable()
    {

        cam.cullingMask += kek;

    }

    private void OnDisable()
    {
        cam.cullingMask -= kek;

    }
}
