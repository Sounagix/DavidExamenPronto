using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    

    public static GameManager instance;

    private GameCanvas gameCanvas;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void WinPanel()
    {
        var cv = GameObject.Find("Canvas");
        if (cv != null)
        {
            gameCanvas = cv.GetComponent<GameCanvas>();
            gameCanvas.WinPanel();
            Time.timeScale = 0.05f;
        }
    }

    public void LosePanel()
    {
        var cv = GameObject.Find("Canvas");
        if (cv != null)
        {
            gameCanvas = cv.GetComponent<GameCanvas>();
            gameCanvas.LosePanel();
            Time.timeScale = 0.05f;
        }
    }

    public void LoadScene(int scene)
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(scene);
    }
}
