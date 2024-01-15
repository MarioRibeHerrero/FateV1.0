using System.Collections;
using System.Collections.Generic;
using Unity.XR.Oculus.Input;
using UnityEngine;

public class PopUpController : MonoBehaviour
{

    [SerializeField] GameObject textToApear, goToHide;


    [SerializeField] bool needTutorial;
    [SerializeField] GameObject tutorial;
    public void ExitPopUp()
    {
        Time.timeScale = 1;
        PlayerInteract.onInteract -= WhenInteract;
        goToHide.SetActive(false);
        if (needTutorial) tutorial.SetActive(false);

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
            if(needTutorial) tutorial.SetActive(true);
            PlayerInteract.onInteract += WhenInteract;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (needTutorial) tutorial.SetActive(false);

            PlayerInteract.onInteract -= WhenInteract;


        }
    }


    private void WhenInteract()
    {
        LoadPopUp();
    }
}
