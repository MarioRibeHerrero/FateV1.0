using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyHealth : MonoBehaviour, IDamageable
{
    private MeleeEnemyState state;
    private RoundManager roundManager;
    private Animator anim;


    DissolvingControllerTut disolveEffect;



    [SerializeField] SkinnedMeshRenderer skinnedMesh;
    private Material[] skinnedMaterials;
    private Color[] originalColors;

    private void Awake()
    {
        disolveEffect = GetComponent<DissolvingControllerTut>();
        state = GetComponent<MeleeEnemyState>();
        anim = GetComponent<Animator>();
        roundManager = FindAnyObjectByType<RoundManager>();



    }






    public bool isDead;
    private void CheckHealth()
    {
        if (state.health <= 0)
        {
            //Aqui hacer cosas de object booling

            

            if(!isDead && roundManager != null) RoudRoomShit();

            //no se usa xq ahora lo llamo con delagados desde el roundmanager
            anim.SetTrigger("Die");
            disolveEffect.Disolve();


        }
    }

    private void RoudRoomShit()
    {
        isDead = true;
        roundManager.roundRoomEnemies.Remove(gameObject);
        if (roundManager.roundRoomEnemies.Count <= 0 && roundManager.inRoundRoom && roundManager.isCristalDestroyed)
        {


            if (roundManager.currentRound == 3)
            {
                roundManager.EndRoundRoom();

            }
            else
            {
                int newRound;
                newRound = roundManager.currentRound + 1;
                roundManager.CallUpdateRound(newRound, 2);

            }

        }



    }
    public void TakeDamage(int damage)
    {

        state.health -= damage;
        CheckHealth();
    }

    private IEnumerator HitAnim()
    {
        // Set the material colors to the flash color
        for (int i = 0; i < skinnedMaterials.Length; i++)
        {
            skinnedMaterials[i].color = Color.white;
        }

        // Wait for the duration of the flash
        yield return new WaitForSeconds(0.15f);

        // Revert the material colors back to the original colors
        for (int i = 0; i < skinnedMaterials.Length; i++)
        {
            skinnedMaterials[i].color = originalColors[i];
        }
    }

}
