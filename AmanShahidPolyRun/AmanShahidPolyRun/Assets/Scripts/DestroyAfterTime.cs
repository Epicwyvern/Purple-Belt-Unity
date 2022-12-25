using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    [Header("Destruction Timer")]
    public float timeToDestruction;
    void Start()
    {
        Invoke("DestroyObject", timeToDestruction);
    }

    // Update is called once per frame
    void DestroyObject()
    {
        Destroy(gameObject);
    }
}

