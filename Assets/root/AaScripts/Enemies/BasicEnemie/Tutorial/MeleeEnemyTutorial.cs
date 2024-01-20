using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.Rendering.DebugUI;

public class MeleeEnemyTutorial : MonoBehaviour
{

    [SerializeField] MeleeEnemyStateController enemy;
    [SerializeField] MeleeEnemyState state;
    [SerializeField] PlayerManager playerManager;



    [SerializeField] GameObject textTutorial;
    [SerializeField] GameObject wallTuto;

    PlayerInput pInput;
    PlayerAnimationManager pAnim;
    Animator anim;

    private bool tutDone;



    [SerializeField] Transform attackRangePos;
    [SerializeField] Vector3 attackRangeVector;
    [SerializeField] LayerMask attackLayer;


    private void Awake()
    {
        pInput = playerManager.transform.GetComponent<PlayerInput>();
        pAnim = playerManager.transform.GetComponent<PlayerAnimationManager>();

        anim = GetComponent<Animator>();

    }

    private void OnEnable()
    {
        pInput.SwitchCurrentActionMap("PlayerTutorial");
        playerManager.transform.GetComponent<PlayerInteract>().SetNewInteract();
    }
    private void Update()
    {
        CheckForPlayer();
    }
    public void ResumeTimeScale()
    {

            textTutorial.SetActive(false);
            Time.timeScale = 1f;
            tutDone = true;
       

    }


    public void StopTime()
    {
        if (tutDone) return;
        textTutorial.SetActive(true);
        Time.timeScale = 0f;

        //

        pInput.SwitchCurrentActionMap("Tutorial");
        pInput.actions["Parry"].started += MeleeEnemyTutorial_started;

    }



    private void MeleeEnemyTutorial_started(InputAction.CallbackContext obj)
    {
        anim.SetTrigger("Stun");
        playerManager.transform.GetComponent<PlayerInteract>().RemoveCurrentInteract();

        pInput.SwitchCurrentActionMap("PlayerNormalMovement");
        playerManager.transform.GetComponent<PlayerInteract>().SetNewInteract();

        pInput.actions["Parry"].started -= MeleeEnemyTutorial_started;
        ResumeTimeScale();
        pAnim.Parry();





    }



    private void PlayerNormal()
    {
        playerManager.canPlayerMove = true;
        playerManager.canPlayerRotate = true;
        wallTuto.SetActive(false);
    }

    bool haveAttack;
    private void CheckForPlayer()
    {
        if (Physics.OverlapBox(attackRangePos.position, attackRangeVector / 2, Quaternion.identity, attackLayer).Length > 0 && !haveAttack)
        {
            anim.SetTrigger("Attack");
            haveAttack = true;
            playerManager.canPlayerMove = false;
            playerManager.canPlayerRotate = false;
        }
    }
}
