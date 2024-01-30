using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class CallMusicOnSwitchRoom : MonoBehaviour
{

    [SerializeField] bool inverse;


    [SerializeField] string AfterMusic;
    [SerializeField] string BeforeMusic;

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("COÑA===??");
        if (inverse)
        {
            if (other.transform.position.x < this.transform.position.x)
            {
                //esta en la siguiente
                MethodInfo methodInfo = AudioManager.Instance.GetType().GetMethod(AfterMusic);
                if (methodInfo != null)
                {
                    methodInfo.Invoke(AudioManager.Instance, null);
                }
                else
                {
                    Console.WriteLine($"Method '{AfterMusic}' not found");
                }

            }
            else
            {
                //esta en la anterior


                MethodInfo methodInfo = AudioManager.Instance.GetType().GetMethod(BeforeMusic);
                if (methodInfo != null)
                {
                    methodInfo.Invoke(AudioManager.Instance, null);
                }
                else
                {
                    Console.WriteLine($"Method '{BeforeMusic}' not found");
                }
            }
        }
        else
        {
            if (other.transform.position.x > this.transform.position.x)
            {
                //esta en la siguiente

                MethodInfo methodInfo = AudioManager.Instance.GetType().GetMethod(AfterMusic);
                if (methodInfo != null)
                {
                    methodInfo.Invoke(AudioManager.Instance, null);
                }
                else
                {
                    Console.WriteLine($"Method '{AfterMusic}' not found");
                }

            }
            else
            {
                //esta en la anterior

                MethodInfo methodInfo = AudioManager.Instance.GetType().GetMethod(BeforeMusic);
                if (methodInfo != null)
                {
                    methodInfo.Invoke(AudioManager.Instance, null);
                }
                else
                {
                    Console.WriteLine($"Method '{BeforeMusic}' not found");
                }
            }
        }


    }
}
