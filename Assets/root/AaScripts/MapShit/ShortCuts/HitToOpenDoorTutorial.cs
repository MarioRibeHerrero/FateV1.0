using UnityEngine;

public class HitToOpenDoorTutorial : MonoBehaviour
{
    [SerializeField] Animator anim;

    public void UnlockDoor()
    {
        anim.SetTrigger("OpenSlow");

    }
}
