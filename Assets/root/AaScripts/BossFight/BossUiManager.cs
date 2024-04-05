using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BossUiManager : MonoBehaviour
{
    [Header("Boss")]
    [SerializeField] GameObject rootBoss;
    private BossFightController bFController;

    [Header("UI")]

    [SerializeField] Image bossHealthImage;
    [SerializeField] GameObject bossHealthGo;
    
    void Awake()
    {
        bFController = rootBoss.GetComponent<BossFightController>();
    }



    private void UpdateHealth()
    {
        bossHealthImage.fillAmount = bFController.bossCurrentHealth / bFController.bossTotalHealth;

    }
    public void EnableHealth()
    {
        bossHealthGo.SetActive(true);
        InvokeRepeating("UpdateHealth", 0, 0.05f);
    }
    public void DisableHealth()
    {
        bossHealthGo.SetActive(false);

    }
}
