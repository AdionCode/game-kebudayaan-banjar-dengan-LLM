using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    bool isPaused = false;
    PlayerCotroller controller;

    private void Awake()
    {
        controller = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCotroller>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseFunc();
        }
    }

    public void PauseFunc()
    {
        pauseMenu.SetActive(!isPaused);
        if (!isPaused)
        {
            controller.enabled = false;
            Time.timeScale = 0f;
        } 
        else
        {
            controller.enabled = true;
            Time.timeScale = 1f;
        }
        isPaused = !isPaused;
    }

    public void RestartGame()
    {
        // Game Scene now
    }

    public void BackToMenu()
    {
        // Menu Scene
    }

}
