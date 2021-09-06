using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 5;
    private bool timerIsRunning = false;
    public Text timeText;
    private GameObject gameManager;
    private SwitchMainMenu switchMainMenu;

    private void Start()
    {
        // Starts the timer automatically
        timerIsRunning = true;

        gameManager = gameObject;
        switchMainMenu = gameManager.GetComponent<SwitchMainMenu>();
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
                switchMainMenu.LoadMainMenu();
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}