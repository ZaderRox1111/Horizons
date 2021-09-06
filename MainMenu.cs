using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private int highscore = 0;
    public Text highscoreText;

    // Start is called before the first frame update
    void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore");
        highscoreText.text = "" + highscore;

        Cursor.lockState = CursorLockMode.None;
    }

    public void LoadMainScene()
    {
        SceneManager.LoadScene("Main Scene");
    }

    public void QuitApp()
    {
        Application.Quit();
    }
}
