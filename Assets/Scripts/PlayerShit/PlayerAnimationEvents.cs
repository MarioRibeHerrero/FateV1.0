using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationEvents : MonoBehaviour
{

    private void CanPlayerMoveToFalse()
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GameManager.Instance.CanPlayerMove = false;
    }
    private void CanPlayerMoveToTrue()
    {
        GameManager.Instance.CanPlayerMove = true;

    }

    private void AttackingHorizontalT()
    {
        GetComponent<Animator>().SetBool("AttackingHorizontal", true);
    }
    private void AttackingHorizontalF()
    {
        GetComponent<Animator>().SetBool("AttackingHorizontal", false);
    }
    private void AttackingVerticalT()
    {
        GetComponent<Animator>().SetBool("AttackingVertical", true);
    }
    private void AttackingVerticalF()
    {
        GetComponent<Animator>().SetBool("AttackingVertical", false);
    }

}
