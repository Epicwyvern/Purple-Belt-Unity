using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [Header("Platform object")]
    public GameObject platform;
    public float pos = 0;
    [Header("Game over UI Canvas Object")]
    public GameObject gameOverCanvas;
    void Start() {
        for (int i = 0; i < 1000; i++) {
            SpawnPlatforms();
        }
    }

    // Update is called once per frame
    void SpawnPlatforms() {
        Instantiate(platform, new Vector3(Random.value * 10 - 5f, pos, 0.5f), Quaternion.identity);
        pos += 5f;
    }

    public void GameOver() {
        gameOverCanvas.SetActive(true);
    }
}
