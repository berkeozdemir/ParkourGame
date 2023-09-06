using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gameover_menu : MonoBehaviour
{
    public void Restar_btn()
    {
        SceneManager.LoadScene("Main");
    }

    public void MainMenu_btn()
    {
        SceneManager.LoadScene("MainMenu");
    }


public void Exit_btn()
    {
        Application.Quit();
    }
   
}
