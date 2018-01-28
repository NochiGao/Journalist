using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class change_scene_from_start_menu : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Return)) {
			SceneManager.LoadScene ("intro", LoadSceneMode.Single);
		}
	}
}
