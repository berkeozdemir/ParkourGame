using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public bool player_alive = true;
    public GameObject death_effect;
    public GameObject hand;
    public GameObject crosshair;
    public GameObject gameOverMenu;
    public PauseGame pause_m;

    public void Death()
    {
        if(player_alive)
        {
            //Set boolean 
            player_alive = false;

            pause_m.isGameOver = true;
            //Particle Effect
            Instantiate(death_effect, transform.position, Quaternion.identity);

            //Disable Player
            GetComponent<PlayerMovement>().enabled = false;
            hand.SetActive(false);
            crosshair.SetActive(false);

            //Cursor Activate
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            //Anable GameOver Menu

            gameOverMenu.SetActive(true);

        }
    }
}
 