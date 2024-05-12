using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject Speed;
    public GameObject score;
    public bool gameIsPaused;
    // Start is called before the first frame update
    void Start()
    {
        gameIsPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
           if (gameIsPaused == true)
            {
                Resume();
                
            }
           if (gameIsPaused == false)
            {
                Pause();
            }
        }
    }
    void Pause()
    {
        gameIsPaused = true;
        pauseMenu.SetActive(true);
        Speed.SetActive(false);
        score.SetActive(false);
        Time.timeScale = 0;
    }
    public void Resume()
    {
        gameIsPaused = false;
        pauseMenu.SetActive(false);
        Speed.SetActive(true);
        score.SetActive(true);
        Time.timeScale = 1;
    }
}
