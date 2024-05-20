using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] LoadingScene scene;
    [SerializeField] GameObject about;

    public void PlayGame()
    {
        scene.LoadScene(1);
    }

    public void AboutGame()
    {
        if (!about.activeSelf)
        {
            about.SetActive(true);
        }
        else
        {
            about.SetActive(false);
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
