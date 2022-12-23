using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Spikes Object for controlling the game")]
    public GameObject spikes;
    [Header("Default height")]
    public float height;
    void Start()
    {
        InvokeRepeating("InstantiateObjects", 1f, 4f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(10, Random.Range(-height, height), 0);
    }

     void InstantiateObjects()
    {
        Instantiate(spikes, transform.position, transform.rotation);
    }
}
