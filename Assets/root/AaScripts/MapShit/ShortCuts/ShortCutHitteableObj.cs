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
        SaveSystem.SaveGameManager(GameManager.Instance);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ActivateShortCut();
        }

    }
}