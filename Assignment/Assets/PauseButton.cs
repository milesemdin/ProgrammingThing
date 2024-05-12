using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PauseButton : MonoBehaviour
{
    public PanelSettings pause;    
    // Start is called before the first frame update
    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            PauseGame();
        }
        else 
        if (Input.GetKey(KeyCode.Escape)) 
        {
            ResumeGame(); 
        }
    }
    void PauseGame()
    {
        Time.timeScale = 0;
    }
    
    void ResumeGame()
    {
        Time.timeScale = 1;
    }
}
