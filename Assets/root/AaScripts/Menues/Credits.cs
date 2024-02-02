using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{

    [SerializeField] PlayerInput playerInput;
    private Animator animator;

    [SerializeField] private bool inCredits;
    [SerializeField] GameObject play;
    void Awake()
    {
        animator = GetComponent<Animator>();
        playerInput.actions["Skip"].started += Credits_started;
        playerInput.actions["Skip"].canceled += Credits_canceled;

    }

    private void Credits_canceled(InputAction.CallbackContext obj)
    {
        if (inCredits)
        {
            animator.SetFloat("ScrollSpeed", 1f);
        }
    }

    private void OnEnable()
    {
        playerInput.SwitchCurrentActionMap("Credits");

    }

    private void OnDisable()
    {
        playerInput.SwitchCurrentActionMap("PlayerNormalMovement");

    }

    private void Credits_started(InputAction.CallbackContext obj)
    {

        if (inCredits)
        {
            animator.SetFloat("ScrollSpeed", 5f);
        }
    }


    public void InCreditsToTrue()
    {
        inCredits = true;
    }

    public void InCreditsToFalse()
    {
        inCredits = false;
        EventSystem.current.SetSelectedGameObject(play);

    }


    public void GoBackToGame()
    {
        this.gameObject.SetActive(false);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
