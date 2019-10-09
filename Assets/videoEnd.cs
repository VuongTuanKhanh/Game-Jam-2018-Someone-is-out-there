using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class videoEnd : MonoBehaviour {

    // Use this for initialization
    private float timeLeft = 35.0f;

    // Update is called once per frame
    void Update () {
        
            timeLeft -= Time.deltaTime;

           
            if (timeLeft <= 0)
            {
                SceneManager.LoadScene(0);
            }
        
    }
}
