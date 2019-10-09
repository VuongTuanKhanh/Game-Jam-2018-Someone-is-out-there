using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class managerSreen : MonoBehaviour {

	// Use this for initialization
	public void startGame()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    

    // Update is called once per frame
    public void quitGame () {
        Application.Quit();
    }

    public void helpGame()
    {
        
        SceneManager.LoadScene(8);
    }
    public void backtoMenu()
    {

        SceneManager.LoadScene(0);
    }
}
