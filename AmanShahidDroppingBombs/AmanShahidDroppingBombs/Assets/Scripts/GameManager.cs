using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private Spawner spawner;
    public GameObject title;
    private Vector2 screenBounds;
    public GameObject playerPrefab;
    private GameObject player;
    private bool gameStarted = false;
    public GameObject splash;
    public GameObject scoreSystem;
    public Text scoreText;
    public int pointsWorth = 1;
    private int score;
    private bool smokeCleared = true;

    private int bestScore = 0;
    public Text bestScoreText;
    private bool beatBestScore;
    void Awake()
    {
        spawner = GameObject.Find("Spawner").GetComponent<Spawner>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        player = playerPrefab;
        scoreText.enabled = false;

        bestScoreText.enabled = false;
    }

    void Start() {
        spawner.active = false;
        title.SetActive(true);
        splash.SetActive(false);

        bestScore = PlayerPrefs.GetInt("Best Score");
        bestScoreText.text = "Best Score: " + bestScore.ToString();
    }

    void Update() {

        if (!gameStarted) {

            Color textColor = new Color(0.196f, 0.196f, 0.196f, 1);

            if (beatBestScore) {
                textColor = new Color(1, 0, 0, 1);
            }

            bestScoreText.color = textColor;
            bestScoreText.text = "Best Score: " + bestScore.ToString();

            if (Input.anyKeyDown && smokeCleared) {
                smokeCleared = false;
                ResetGame();
            }
        } else {

            bestScoreText.text = "";

            if (!player) {
                OnPlayerKilled();
            }
        }

        var nextBomb = GameObject.FindGameObjectsWithTag("Bomb");

        foreach(GameObject bombObject in nextBomb) {
            if (!gameStarted) {
                Destroy(bombObject);
            } else if(bombObject.transform.position.y < (-screenBounds.y)) {
                scoreSystem.GetComponent<Score>().AddScore(pointsWorth);
                Destroy(bombObject);
            }
        }
    }

    void ResetGame() {
        spawner.active = true;
        title.SetActive(false);
        splash.SetActive(false);
        player = Instantiate(playerPrefab, new Vector3(0, 0, 0), playerPrefab.transform.rotation);
        gameStarted = true;
        scoreText.enabled = true;
        scoreSystem.GetComponent<Score>().score = 0;
        scoreSystem.GetComponent<Score>().Start();

        beatBestScore = false;
        bestScoreText.enabled = true;
    }

    void OnPlayerKilled () {
        spawner.active = false;
        gameStarted = false;
        Invoke("SplashScreen", 2f);

        score = scoreSystem.GetComponent<Score>().score;

        if (score > bestScore) {
            bestScore = score;
            PlayerPrefs.SetInt("Best Score", bestScore);
            beatBestScore = true;
            bestScoreText.text = "Best Score: " + bestScore.ToString();
        }
    }

    void SplashScreen () {
        smokeCleared = true;
        splash.SetActive(true);
    }
}
