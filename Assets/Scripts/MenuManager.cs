using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject PauseMenuUI;

    // Update is called once per frame

    private void Start()
    {
        if (PauseMenuUI != null)
        {
            PauseMenuUI.SetActive(false);
        }
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {

            //If not passed in pause menu, then we are in the main menu so quit
            if (PauseMenuUI != null)
            {
                Pause();
            }
            else
            {
                QuitGame();
            }
        }
    }

    public void Pause()
    {

        if (PauseMenuUI != null)
        {
            PauseMenuUI.SetActive(true);
            //Set timescale to 0 to pause the game
            Time.timeScale = 0.0f;
        }
    }

    public void Resume()
    {

        if (PauseMenuUI != null)
        {
            PauseMenuUI.SetActive(false);
            //Set timescale to 1 to resume the game
            Time.timeScale = 1.0f;
        }
    }

    public void LoadGame()
    {
        Time.timeScale = 1.0f;
        //Load scene. For the time being I prefer to use name, however I believe it is better to use build index.
        SceneManager.LoadScene("Game");
    }


    public void LoadMainMenu()
    {
        Time.timeScale = 1.0f;
        //Load scene. For the time being I prefer to use name, however I believe it is better to use build index.
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Debug.Log("You have quit the game!");
        Application.Quit();
    }
}
