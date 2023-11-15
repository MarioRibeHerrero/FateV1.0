using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationEvents : MonoBehaviour
{
    private void CanPlayerMoveToFalse()
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GameManager.Instance.canPlayerMove = false;
    }
    private void CanPlayerMoveToTrue()
    {
        GameManager.Instance.canPlayerMove = true;

    }

    private void IsOcupiedToTrue()
    {
        GetComponent<Animator>().SetBool("IsOccupied", true);
        GameManager.Instance.isOccupied = true;

    }
    private void IsOcupiedToFalse()
    {
        GetComponent<Animator>().SetBool("IsOccupied", false);
        GameManager.Instance.isOccupied = false;
    }
    private void CanRotateToTrue()
    {
        GetComponent<Animator>().SetBool("CanRotate", true);
        GameManager.Instance.canPlayerRotate = true;
    }
    private void CanRotateToFalse()
    {
        GetComponent<Animator>().SetBool("CanRotate", false);
        GameManager.Instance.canPlayerRotate = false;
    }

    private void Parry()
    {
        GetComponent<PlayerHealth>().TakeDamage(30);
        GameManager.Instance.isPlayerParry = true;
    }
    private void ParryEnd()
    {
        GameManager.Instance.isPlayerParry = false;

    }
    
}
