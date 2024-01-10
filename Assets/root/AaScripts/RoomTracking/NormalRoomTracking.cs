using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NormalRoomTracking : MonoBehaviour
{
    #region Vars
    [Header("Using colliders")]
    [SerializeField] GameManager.Rooms previusRoom, nextRoom;

    [SerializeField] bool inverse;

    private CameraManager camManager;
    #endregion

    private void Awake()
    {
        camManager = GameObject.FindAnyObjectByType<CameraManager>();
    }
    private void OnTriggerExit(Collider other)
    {
        if (inverse)
        {
            if (other.transform.position.x < this.transform.position.x)
            {
                //esta en la siguiente

                GameManager.Instance.currentRoom = nextRoom;
                camManager.SetNewCamera(nextRoom);
                camManager.DisableOldCamera(previusRoom);
                Debug.Log("SI");
            }
            else
            {
                //esta en la anterior
                GameManager.Instance.currentRoom = previusRoom;
                camManager.SetNewCamera(previusRoom);
                camManager.DisableOldCamera(nextRoom);
                Debug.Log("NO");

            }
        }
        else
        {
            if (other.transform.position.x > this.transform.position.x)
            {
                //esta en la siguiente

                GameManager.Instance.currentRoom = nextRoom;
                camManager.SetNewCamera(nextRoom);
                camManager.DisableOldCamera(previusRoom);
            }
            else
            {
                //esta en la anterior
                GameManager.Instance.currentRoom = previusRoom;
                camManager.SetNewCamera(previusRoom);
                camManager.DisableOldCamera(nextRoom);

            }
        }


    }

}
