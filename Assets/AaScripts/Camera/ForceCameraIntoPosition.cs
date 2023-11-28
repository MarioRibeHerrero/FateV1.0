using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceCameraIntoPosition : MonoBehaviour
{

    void Update()
    {
        this.transform.rotation = Quaternion.Euler(1.26f, 0.153f, 0);
    }
}
