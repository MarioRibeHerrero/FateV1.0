using UnityEngine;

public class HitToOpenDoorTutorial : MonoBehaviour
{
    [SerializeField] Animator anim;

    public void UnlockDoor()
    {
        Debug.Log("ASDPJA)SDHAS");
        anim.SetTrigger("OpenSlow");

    }
}
