using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] UiManager uiManager;
    public Transform currentSpawnPoint;


    private RoundEnrtyCollider entryCollider;

   
    void Start()
    {
        GameManager.Instance.isPlayerAlive = true;
        entryCollider = GameObject.FindAnyObjectByType<RoundEnrtyCollider>().GetComponent<RoundEnrtyCollider>();

    }


    public void TakeDamage(float damage)
    {
        GameManager.Instance.playerHealth -= damage;
        CheckHealth();
        uiManager.UpdatePlayerHealthSlider();
    }

    public void HealPlayer(float healAmmount)
    {
        GameManager.Instance.playerHealth += healAmmount;
        CheckHealth();
        uiManager.UpdatePlayerHealthSlider();
    }
    private void CheckHealth()
    {
        if(GameManager.Instance.playerHealth <= 0)
        {

            if (GameManager.Instance.inRoundRoom)
            {

                //ResetearLaRoom
                //PONER CUNADO SE ACABE DE VERDAD
                GameManager.Instance.inRoundRoom = false;
                entryCollider.gameObject.transform.parent.GetComponent<Animator>().SetTrigger("OpenDoors");
                entryCollider.doorsColsed = false;
                for (int i = GameManager.Instance.roundRoomEnemies.Count - 1; i >= 0; i--)
                {
                    Debug.Log(i);
                    Debug.Log(GameManager.Instance.roundRoomEnemies.Count);

                    // Get the first GameObject in the list
                    GameObject enemyToRemove = GameManager.Instance.roundRoomEnemies[i];

                    string prefabName = enemyToRemove.name + "(Clone)";

                    // Remove the GameObject from the list
                    GameManager.Instance.roundRoomEnemies.RemoveAt(i);

                    Destroy(GameObject.Find(prefabName));
                }
                //-----------------
            }

            GameManager.Instance.isPlayerAlive = false;
            DesactivateAllPlayerFuntionsAndKill();
            StartCoroutine(RevivePlayer());

        }
    }


    private void DesactivateAllPlayerFuntionsAndKill()
    {
        transform.Find("Body").transform.gameObject.SetActive(false);

        GetComponent<PlayerMovement>().enabled = false;
        GetComponent<PlayerRotation>().enabled = false;
        GetComponent<PlayerJump>().enabled = false;
        GetComponent<PlayerParry>().enabled = false;
        GetComponent<PlayerAa>().enabled = false;
        GetComponent<PlayerHook>().enabled = false;

    }


    private void ActivateAllPlayerFuntionsAndKill()
    {

        GetComponent<PlayerMovement>().enabled = true;
        GetComponent<PlayerRotation>().enabled = true;
        GetComponent<PlayerJump>().enabled = true;
        GetComponent<PlayerParry>().enabled = true;
        GetComponent<PlayerAa>().enabled = true;
        GetComponent<PlayerHook>().enabled = true;

    }

    private IEnumerator RevivePlayer()
    {
        yield return new WaitForSeconds(1);
        transform.position = currentSpawnPoint.transform.position;
        transform.Find("Body").transform.gameObject.SetActive(true);
        ActivateAllPlayerFuntionsAndKill();
        GameManager.Instance.playerHealth = 100f;
        uiManager.UpdatePlayerHealthSlider();

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Death"))
        {
            TakeDamage(100);
        }
    }

}
