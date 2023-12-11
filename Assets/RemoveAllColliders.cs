using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveAllColliders : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        RemoveCollidersRecursively();
    }

    // Update is called once per frame

    private void RemoveCollidersRecursively()
    {
        var allColliders = GetComponentsInChildren<Collider>();

        foreach (var childCollider in allColliders) Destroy(childCollider);
    }
}
