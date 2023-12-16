using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    [Header("HUD")]
    [SerializeField] Slider playerHealthSlider;
    [SerializeField] Image parryCd;

    private void FixedUpdate()
    {
        
    }
    public void UpdatePlayerHealthSlider()
    {
        playerHealthSlider.value = GameManager.Instance.playerHealth /100;
       // Debug.Log("asdas");
    }
}
