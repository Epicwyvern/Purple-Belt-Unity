using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject gameOverCanvas;
    public GameObject[] shapePrefabs;
    public float spawnDelay = 1f;
    public float spawnTime = 2f;
    void Start()
    {
        InvokeRepeating("Spawn", spawnDelay, spawnTime);
    }

    // Update is called once per frame
    void Spawn()
    {
        int randomInt = Random.Range(0, shapePrefabs.Length);
        Instantiate(shapePrefabs[randomInt], Vector3.zero, Quaternion.identity);
    }

    public void GameOver() {
        Time.timeScale = 0;
        gameOverCanvas.SetActive(true);
        CancelInvoke("Spawn");
    }

    public void Restart() {
        SceneManager.LoadScene(0);
    }
}
