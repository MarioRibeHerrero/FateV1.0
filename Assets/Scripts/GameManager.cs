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
    public float playerHealth;
    public bool isPlayerAlive;
    public bool CanPlayerMove;
}