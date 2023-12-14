using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camPrueba : MonoBehaviour
{
    public GameObject target;
    public Vector3 offset;



    void Start()
    {
        offset = new Vector3(0, 0, -10);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = target.transform.position + offset;
        Vector3 targetPositionY = target.transform.position + offset; 
        //transform.position = Vector3.SmoothDamp(transform.position, targetPositionY, Vector3.zero , 0.3f);

    }
}
