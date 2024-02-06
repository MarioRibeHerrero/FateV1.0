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
        if (textToApear == null) return;
        Debug.Log("FADE");
        Time.timeScale = 1;
        PlayerInteract.onInteract -= WhenInteract;
        canvasTutorial = true;
        if (needTutorial) tutorial.SetActive(false);
        textToApear.GetComponent<Animator>().SetTrigger("Exit");
        

    }
    private void LoadPopUp()
    {
        if (textToApear == null) return;
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
        if (textToApear == null) return;
        LoadPopUp();
    }

    private void OnInteractAfterTut()
    {
        if (textToApear == null) return;
        tutorial.GetComponent<Animator>().SetTrigger("Exit");

    }
}
