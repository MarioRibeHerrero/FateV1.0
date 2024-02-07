using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class DissolvingControllerTut : MonoBehaviour
{


    public SkinnedMeshRenderer skinnedMesh;
    public float dissolveRate = 0.0255f;
    public float refreshRate = 0.025f;

    private Material[] skinnedMaterials; 
    
    void Start()
    {

        if (skinnedMesh != null)
            skinnedMaterials = skinnedMesh.materials;
    }


    public void Reset()
    {
        for (int i = 0; i < skinnedMaterials.Length; i++)
        {
            skinnedMaterials[i].SetFloat("_DissolveAmount", 0);
        }
    }
    public void Disolve()
    {
        StartCoroutine(DissolveCo());
    }
    IEnumerator DissolveCo()
    {
         if(skinnedMaterials.Length > 0)
        {
            float counter = 0;
            while (skinnedMaterials[0] .GetFloat("_DissolveAmount") < 1)
            {

                counter += dissolveRate;
                for (int i = 0;  i <skinnedMaterials.Length; i++)
                {
                    skinnedMaterials[i].SetFloat("_DissolveAmount", counter);
                }
                yield return new WaitForSeconds(refreshRate);
            }

        }
        
    
    }
}
