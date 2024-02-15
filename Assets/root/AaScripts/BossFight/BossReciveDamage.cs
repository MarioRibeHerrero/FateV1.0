using System.Collections;
using UnityEngine;

public class BossReciveDamage : MonoBehaviour, IDamageable
{

    [SerializeField] GameObject bossFightController;
    private Animator attackAnimator;
    private BossHealth bossHealth;
    private BossFightController bossFControllerScript;

    private Animator anim;
    private void Awake()
    {
        bossHealth = bossFightController.GetComponent<BossHealth>();
        bossFControllerScript = bossFightController.GetComponent<BossFightController>();
        attackAnimator = bossFightController.GetComponent<Animator>();
        anim = GetComponent<Animator>();
    }


    public void TakeDamage(int damageTaken)
    {
        StartCoroutine(SlowTime());
        anim.SetTrigger("Hit");
        bossFControllerScript.bossCurrentHealth -= damageTaken;
        bossHealth.CheckHealth();
    }

    private IEnumerator SlowTime()
    {
        Time.timeScale = 0.3f;
        yield return new WaitForSeconds(0.05f);
        Time.timeScale = 1f;

    }

}
