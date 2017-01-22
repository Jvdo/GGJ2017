using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PickLevel(string level)
    {
        SceneManager.LoadScene("Level " + level);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
