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
        if (inverse)
        {
            if (other.transform.position.x < this.transform.position.x)
            {
                //esta en la siguiente

                AudioManager.Instance.GetType().GetMethod(AfterMusic);
            }
            else
            {
                //esta en la anterior

                AudioManager.Instance.GetType().GetMethod(BeforeMusic);

            }
        }
        else
        {
            if (other.transform.position.x > this.transform.position.x)
            {
                //esta en la siguiente

                AudioManager.Instance.GetType().GetMethod(AfterMusic);

            }
            else
            {
                //esta en la anterior

                AudioManager.Instance.GetType().GetMethod(BeforeMusic);

            }
        }


    }
}
