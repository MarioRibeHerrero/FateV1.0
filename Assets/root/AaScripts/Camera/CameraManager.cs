using System.Collections;

using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{

    [SerializeField] GameObject Room_1_1;

    [SerializeField] GameObject Room_1_2;
    [SerializeField] GameObject Room_1_2_1;
    [SerializeField] GameObject Room_1_2_2;

    [SerializeField] GameObject Room_1_3;
    [SerializeField] GameObject Room_1_3_1;


    [SerializeField] GameObject Room_1_4;
    [SerializeField] GameObject Room_1_4_1;

    [SerializeField] GameObject Room_1_5;
    [SerializeField] GameObject Room_1_5_1;
    [SerializeField] GameObject Room_1_5_2;

    [SerializeField] GameObject Room_1_6;

    [SerializeField] GameObject Room_1_7;







    public void SetNewCamera(GameManager.Rooms NewRoom)
    {
        switch (NewRoom)
        {
            case GameManager.Rooms.Room_1_1:
                Room_1_1.SetActive(true);
                break;


            case GameManager.Rooms.Room_1_2:
                Room_1_2.SetActive(true);
                break;
            case GameManager.Rooms.Room_1_2_1:
                Room_1_2_1.SetActive(true);
                break;
            case GameManager.Rooms.Room_1_2_2:
                Room_1_2_2.SetActive(true);
                break;



            case GameManager.Rooms.Room_1_3:
                Room_1_3.SetActive(true);
                break;
            case GameManager.Rooms.Room_1_3_1:
                Room_1_3_1.SetActive(true);
                break;
                


            case GameManager.Rooms.Room_1_4:
                Room_1_4.SetActive(true);
                break;
            case GameManager.Rooms.Room_1_4_1:
                Room_1_4_1.SetActive(true);
                break;



            case GameManager.Rooms.Room_1_5:
                Room_1_5.SetActive(true);
                break;
            case GameManager.Rooms.Room_1_5_1:
                Room_1_5_1.SetActive(true);
                break;
            case GameManager.Rooms.Room_1_5_2:
                Room_1_5_2.SetActive(true);
                break;



            case GameManager.Rooms.Room_1_6:
                Room_1_6.SetActive(true);
                break;



            case GameManager.Rooms.Room_1_7:
                Room_1_7.SetActive(true);
                break;




        }
    }
    public void DisableOldCamera(GameManager.Rooms previusRoom)
    {
        switch (previusRoom)
        {
            case GameManager.Rooms.Room_1_1:
                Room_1_1.SetActive(false);
                break;


            case GameManager.Rooms.Room_1_2:
                Room_1_2.SetActive(false);
                break;
            case GameManager.Rooms.Room_1_2_1:
                Room_1_2_1.SetActive(false);
                break;
            case GameManager.Rooms.Room_1_2_2:
                Room_1_2_2.SetActive(false);
                break;



            case GameManager.Rooms.Room_1_3:
                Room_1_3.SetActive(false);
                break;
            case GameManager.Rooms.Room_1_3_1:
                Room_1_3_1.SetActive(false);
                break;



            case GameManager.Rooms.Room_1_4:
                Room_1_4.SetActive(false);
                break;
            case GameManager.Rooms.Room_1_4_1:
                Room_1_4_1.SetActive(false);
                break;



            case GameManager.Rooms.Room_1_5:
                Room_1_5.SetActive(false);
                break;
            case GameManager.Rooms.Room_1_5_1:
                Room_1_5_1.SetActive(false);
                break;
            case GameManager.Rooms.Room_1_5_2:
                Room_1_5_2.SetActive(false);
                break;



            case GameManager.Rooms.Room_1_6:
                Room_1_6.SetActive(false);
                break;



            case GameManager.Rooms.Room_1_7:
                Room_1_7.SetActive(false);
                break;

        }
    }
}
