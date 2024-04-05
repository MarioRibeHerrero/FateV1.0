using System.Collections;
using System.Collections.Generic;
using Unity.XR.Oculus.Input;
using UnityEngine;
using UnityEngine.Rendering;

public class PopUpController : MonoBehaviour
{

    [SerializeField] bool disapearAfterOneUse;
    bool hasBeenUsed;

    [SerializeField] GameObject textToApear;


    [SerializeField] bool needTutorial;
    [SerializeField] GameObject tutorial;

    [SerializeField] private bool popUpInstant;
    private bool canvasTutorial;
    public void ExitPopUp()
    {
        if (textToApear == null) return;
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

            if (disapearAfterOneUse)
            {
                if (needTutorial && !hasBeenUsed)
                {
                    tutorial.SetActive(true);
                    PlayerInteract.onInteract += InteractOnTutorial;
                }
            }
            else
            {
                if (needTutorial)
                {
                    tutorial.SetActive(true);
                    PlayerInteract.onInteract += InteractOnTutorial;
                }
            }



            if(!canvasTutorial)PlayerInteract.onInteract += WhenInteract;
            if(canvasTutorial || !needTutorial) PlayerInteract.onInteract += OnInteractAfterTut;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (needTutorial)
            {
                tutorial.GetComponent<Animator>().SetTrigger("Exit");
                PlayerInteract.onInteract -= InteractOnTutorial;

            }




            if (!canvasTutorial)PlayerInteract.onInteract -= WhenInteract;
            if(canvasTutorial || !needTutorial) PlayerInteract.onInteract -= OnInteractAfterTut;
        }
    }


    private void WhenInteract()
    {
        if (textToApear == null) return;

        if (popUpInstant)
        {
            LoadPopUp();
        }
        else
        {
            Invoke(nameof(LoadPopUp), 1.80f);
        }
    }

    private void OnInteractAfterTut()
    {
        if (textToApear == null) return;
        tutorial.GetComponent<Animator>().SetTrigger("Exit");

    }


    private void InteractOnTutorial()
    {
        hasBeenUsed = true;

        tutorial.SetActive(false);
    }
}
