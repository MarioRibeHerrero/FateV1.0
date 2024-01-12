using System.Collections;
using System.Collections.Generic;
using Unity.XR.Oculus.Input;
using UnityEngine;

public class PopUpController : MonoBehaviour
{

    [SerializeField] GameObject textToApear, goToHide;


    
    public void ExitPopUp()
    {
        Time.timeScale = 1;
        PlayerInteract.onInteract -= WhenInteract;
        goToHide.SetActive(false);

    }
    private void LoadPopUp()
    {
        Time.timeScale = 0;
        textToApear.SetActive(true);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            PlayerInteract.onInteract += WhenInteract;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            PlayerInteract.onInteract -= WhenInteract;


        }
    }


    private void WhenInteract()
    {
        LoadPopUp();
    }
}
