using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    
    public void PlayGame()
    {
        /*SceneManager controls the flow of scenes,
        in this one it is checking the active scenes 
        number adding 1 to it and loading*/
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        //Simply quits the application.
        Application.Quit();
    }
}
