using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;

public class DissolvingControllerTut : MonoBehaviour
{


    public SkinnedMeshRenderer skinnedMesh;
    public SkinnedMeshRenderer hacha;

    public float dissolveRate = 0.0255f;
    public float refreshRate = 0.025f;

    private Material[] skinnedMaterials; 
    
    void Start()
    {
        if (skinnedMesh != null && hacha != null)
        {
            // Combine materials from both SkinnedMeshRenderers into one array
            skinnedMaterials = new Material[skinnedMesh.materials.Length + hacha.materials.Length];
            Array.Copy(skinnedMesh.materials, skinnedMaterials, skinnedMesh.materials.Length);
            Array.Copy(hacha.materials, 0, skinnedMaterials, skinnedMesh.materials.Length, hacha.materials.Length);

            // Assign the combined materials array to skinnedMesh
            //skinnedMesh.materials = skinnedMaterials;
        }
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
