using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{


    public static GameManager Instance;
    private void Awake()
    {


        Instance = this;

    }


    //PlayerThings

    //camera
    public bool thirdPersonCam;
    //Rooms
    public enum Rooms
    {
        Room_1_1,

        Room_1_2,
        Room_1_2_1,
        Room_1_2_2,

        Room_1_3,
        Room_1_3_1,

        Room_1_4,
        Room_1_4_1,

        Room_1_5,
        Room_1_5_1,
        Room_1_5_2,

        Room_1_6,

        Room_1_7,


    }
    [Header("RoomTracker")]
    public Rooms currentRoom;
    public Rooms RespawnRoom;


}