using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenceSfx : MonoBehaviour
{
     private void PlayLockSound()
     {
        AudioManager.Instance.PlayOpenLock();

    }
    private void PlayOpenDoor()
    {
        AudioManager.Instance.PlayOpenMetalDoor();
    }
}
