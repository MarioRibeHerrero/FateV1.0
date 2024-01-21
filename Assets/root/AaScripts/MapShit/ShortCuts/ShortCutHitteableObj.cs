using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortCutHitteableObj : MonoBehaviour
{
    [SerializeField] GameObject go;





    public void ActivateShortCut()
    {
        go.SetActive(true);
        GameManager.Instance.shortCutUnlocked = true;
        Destroy(gameObject);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerAa"))
        {
            ActivateShortCut();
        }

    }
}
