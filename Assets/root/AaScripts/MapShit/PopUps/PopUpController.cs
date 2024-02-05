using System.Collections;
using System.Collections.Generic;
using Unity.XR.Oculus.Input;
using UnityEngine;

public class PopUpController : MonoBehaviour
{

    [SerializeField] GameObject textToApear;


    [SerializeField] bool needTutorial;
    [SerializeField] GameObject tutorial;


    private bool canvasTutorial;
    public void ExitPopUp()
    {
        Time.timeScale = 1;
        PlayerInteract.onInteract -= WhenInteract;
        canvasTutorial = true;
        textToApear.GetComponent<Animator>().SetTrigger("Exit");
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
            if(!canvasTutorial)PlayerInteract.onInteract += WhenInteract;
            
            if(canvasTutorial || !needTutorial) PlayerInteract.onInteract += OnInteractAfterTut;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (needTutorial) tutorial.GetComponent<Animator>().SetTrigger("Exit");

            if(!canvasTutorial)PlayerInteract.onInteract -= WhenInteract;
            
            
            if(canvasTutorial || !needTutorial) PlayerInteract.onInteract -= OnInteractAfterTut;



        }
    }


    private void WhenInteract()
    {
        LoadPopUp();
    }

    private void OnInteractAfterTut()
    {
        Debug.Log(("JASODJASONFIAUB"));
        tutorial.GetComponent<Animator>().SetTrigger("Exit");

    }
}
