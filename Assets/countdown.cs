using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class countdown : MonoBehaviour {

    // Use this for initialization
    IEnumerator Start () {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(0);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
