using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassageCam : MonoBehaviour
{
    [SerializeField] private GameObject player;

    Vector3 velocity = Vector3.zero;

    // Update is called once per frame
    void Update()
    {
        
        Vector3 targetPositionY = new Vector3(player.transform.position.x, this.transform.position.y, this.transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, targetPositionY, ref velocity, 0.3f);
    }
}
