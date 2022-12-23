using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControls: MonoBehaviour
{
    public GameObject timerCanvas;
    private Text timerText;
    private int timerCount;
    void Start()
    {
        timerCanvas.SetActive(true);
        StartCoroutine(CountTime());
        Time.timeScale = 1f;
        timerText = GameObject.Find("Score").GetComponent<Text>();
    }

    // Update is called once per frame
    IEnumerator CountTime()
    {
        yield return new WaitForSeconds(1f);
        timerCount++;
        timerText.text = "Score: " + timerCount;
        StartCoroutine(CountTime());
    }
}
