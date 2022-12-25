using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("ChallengeObj Game Object")]
    public GameObject challengeObject;
    [Header("Default spawn time delay")]
    public float spawnDelay = 1f;

    [Header("Default spawn time")]
    public float spawnTime = 2f;
    void Start()
    {
        InvokeRepeating("InstantiateObejcts", spawnDelay, spawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(15, 0, 0);
    }

    void InstantiateObejcts()
    {
        Instantiate(challengeObject, transform.position, transform.rotation);
    }
}

