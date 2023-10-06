using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject FixedJoystick;
    [SerializeField] GameObject RollJoystick;
    [SerializeField] GameObject HorizontalJoystick;

    public void Pause()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        FixedJoystick.SetActive(false);
        RollJoystick.SetActive(false);
        HorizontalJoystick.SetActive(false);
        
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        FixedJoystick.SetActive(true);
        RollJoystick.SetActive(true);
        HorizontalJoystick.SetActive(true);
        
    }

    public void Home(int sceneID)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneID);
    }

}
