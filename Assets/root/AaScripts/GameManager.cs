using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class GameManager : MonoBehaviour
{


    public static GameManager Instance;
    private void Awake()
    {


        Instance = this;
        DontDestroyOnLoad(this);

    }

    
    //Loading Game

    public bool isGameLoaded;

    //if camera is thirdperson
    public bool thirdPersonCam;
    //Room Enum
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
        Room_1_6_1,

        Room_1_7,


    }


    //para que cunado modifiques estos valores pasen cosas
    public float RespawnPointF
    {
        get
        {

            SwitchConvertidor();
            return respawnPointF;
        }
        set
        {

            respawnPointF = value;
            SwitchConvertidor2();
        }
    }
    public Rooms RespawnRoom
    {
        get
        {
            return respawnRoom; 
        }
        set
        {
            SwitchConvertidor();

            respawnRoom = value;
            currentRoom = value;
        }
    }

    //Info de rooms
    public Rooms respawnRoom;
    public Rooms currentRoom;

    //Valores guardados
    public float respawnPointF;
    public Vector3 respawnVector;

    //convertidores para el guardado de en que habitacion respawneas
    private void SwitchConvertidor2()
    {
        switch (respawnPointF)
        {
            case 1.1f:
                respawnRoom = Rooms.Room_1_1;
                currentRoom = Rooms.Room_1_1;
                break;


            case 1.2f:
                respawnRoom = Rooms.Room_1_2;
                currentRoom = Rooms.Room_1_2;


                break;
            case 1.21f:
                respawnRoom = Rooms.Room_1_2_1;
                currentRoom = Rooms.Room_1_2_1;


                break;
            case 1.22f:
                respawnRoom = Rooms.Room_1_2_2;
                currentRoom = Rooms.Room_1_2_2;

                break;



            case 1.3f:
                respawnRoom = Rooms.Room_1_3;
                currentRoom = Rooms.Room_1_3;

                break;
            case 1.31f:
                respawnRoom = Rooms.Room_1_3_1;
                currentRoom = Rooms.Room_1_3_1;

                break;


            case 1.4f:
                respawnRoom = Rooms.Room_1_4;
                currentRoom = Rooms.Room_1_4;

                break;
            case 1.41f:
                respawnRoom = Rooms.Room_1_4_1;
                currentRoom = Rooms.Room_1_4_1;

                break;



            case 1.5f:
                respawnRoom = Rooms.Room_1_5;
                currentRoom = Rooms.Room_1_5;

                break;
            case 1.51f:
                respawnRoom = Rooms.Room_1_5_1;
                currentRoom = Rooms.Room_1_5_1;

                break;
            case 1.52f:
                respawnRoom = Rooms.Room_1_5_2;
                currentRoom = Rooms.Room_1_5_2;

                break;



            case 1.6f:
                respawnRoom = Rooms.Room_1_6;
                currentRoom = Rooms.Room_1_6;

                break;



            case 1.7f:
                respawnRoom = Rooms.Room_1_7;
                currentRoom = Rooms.Room_1_7;

                break;




        }
    }

    private void SwitchConvertidor()
    {
        switch (RespawnRoom)
        {
            case GameManager.Rooms.Room_1_1:
                respawnPointF = 1.1f;
                break;


            case GameManager.Rooms.Room_1_2:
                respawnPointF = 1.2f;
                break;
            case GameManager.Rooms.Room_1_2_1:
                respawnPointF = 1.21f;
                break;
            case GameManager.Rooms.Room_1_2_2:
                respawnPointF = 1.22f;
                break;



            case GameManager.Rooms.Room_1_3:
                respawnPointF = 1.3f;
                break;
            case GameManager.Rooms.Room_1_3_1:
                respawnPointF = 1.31f;
                break;



            case GameManager.Rooms.Room_1_4:
                respawnPointF = 1.4f;
                break;
            case GameManager.Rooms.Room_1_4_1:
                respawnPointF = 1.41f;
                break;



            case GameManager.Rooms.Room_1_5:
                respawnPointF = 1.5f;
                break;
            case GameManager.Rooms.Room_1_5_1:
                respawnPointF = 1.51f;
                break;
            case GameManager.Rooms.Room_1_5_2:
                respawnPointF = 1.52f;
                break;



            case GameManager.Rooms.Room_1_6:
                respawnPointF = 1.6f;
                break;



            case GameManager.Rooms.Room_1_7:
                respawnPointF = 1.7f;
                break;




        }
    }


}