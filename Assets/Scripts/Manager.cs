using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public static bool GameIsOver;

    public GameObject gameOverUI;

    public GameObject completeLevelUI;

    public string nextLevel = "Level3";
    public int levelToUnlock = 3;

    void Start ()
    {
        GameIsOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameIsOver)
        {
            return;
        }

        /* TESTAVIMUI
        if (Input.GetKeyDown("e"))
        {
            EndGame();
        }
        if (Input.GetKeyDown("e"))
        {
            WinLevel();
        }

        if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }
        */
    }

    void EndGame()
    {
        GameIsOver = true;

        gameOverUI.SetActive(true);
    }
    public void WinLevel()
    {
        GameIsOver = true;
        PlayerPrefs.SetInt("levelReached", levelToUnlock);
        completeLevelUI.SetActive(true);
    }
}
