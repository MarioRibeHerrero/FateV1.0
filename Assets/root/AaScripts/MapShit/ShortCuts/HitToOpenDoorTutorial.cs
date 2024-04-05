using UnityEngine;

public class HitToOpenDoorTutorial : MonoBehaviour
{
    [SerializeField] Animator anim;

    public void UnlockDoor()
    {
        AudioManager.Instance.PlayOpenLock();
        Invoke(nameof(OpenDoor), 0.75f);
    }


    private void OpenDoor()
    {
        AudioManager.Instance.PlayOpenMetalDoor();

        anim.SetTrigger("OpenSlow");

    }
}
