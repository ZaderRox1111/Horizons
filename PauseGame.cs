using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour
{
    public GameObject panel;
    public FirstPersonController fpc;
    private bool isPaused = false;

    private void Start()
    {
        panel.SetActive(false);
    }

    private void Update()
    {
        if (!isPaused)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                PausingGame();
            }
        } else
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                UnpauseGame();
            }
        }
    }

    void PausingGame()
    {
        panel.SetActive(true);
        Time.timeScale = 0;
        fpc.cameraCanMove = false;
        Cursor.lockState = CursorLockMode.None;
    }

    public void UnpauseGame()
    {
        panel.SetActive(false);
        Time.timeScale = 1;
        fpc.cameraCanMove = true;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
