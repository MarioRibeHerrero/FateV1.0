using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookVfxController : MonoBehaviour
{

    [SerializeField] ParticleSystem[] particleSystems;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < particleSystems.Length; i++)
        {
            particleSystems[i].Stop();
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < particleSystems.Length; i++)
        {
            particleSystems[i].Play();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        for (int i = 0; i < particleSystems.Length; i++)
        {
            particleSystems[i].Stop();
        }
    }
}
