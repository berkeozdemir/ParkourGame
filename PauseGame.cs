using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    private bool isGamePaused = false;

    public GameObject pauseMenu_obj;

    public bool isGameOver = false;

    public GameObject player, pistol;

    public AudioSource music;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !isGameOver)
        {
            if(!isGamePaused)
            {
                Pause ();
            }
            else
            {
                Resume();
            }
        }
    }

    private void Pause()
    {
        Time.timeScale = 0;

        music.Pause();

        player.GetComponent<PlayerMovement>().enabled = false;
        pistol.GetComponent<WP>().enabled = false;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        pauseMenu_obj.SetActive(true);
        isGamePaused = true;
    }

    private void Resume()
    {
        Time.timeScale = 1;

        music.UnPause();

        player.GetComponent<PlayerMovement>().enabled = true;
        pistol.GetComponent<WP>().enabled = true;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;


        pauseMenu_obj.SetActive(false);
        isGamePaused = false;
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void OpenMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
