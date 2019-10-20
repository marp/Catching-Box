using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F12)) //enable or disable fullscreen on F12
        {
            if (Screen.fullScreen)
            {
                Screen.fullScreen = false;
            }
            else
            {
                Screen.fullScreen = true;
            }
        }
    }

    public void ExitFromGame()
    {
        Application.Quit();
    }

    public void LoadGameLevel()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadHelp()
    { 
        SceneManager.LoadScene(1);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

}
