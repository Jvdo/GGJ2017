using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour {

    public void StartGame()
    {
        SceneManager.LoadScene("Level 1");
    }
    public void LevelSelect()
    {
        SceneManager.LoadScene("Level Select");
    }
    public void Options()
    {
        SceneManager.LoadScene("Credits");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
