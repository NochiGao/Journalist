using UnityEngine;
using UnityEngine.SceneManagement;

public class change_scene_from_start_menu : MonoBehaviour
{
    private void Start()
    {
        AudioManager.Instance.MenuStart();
    }

    void Update () {

		if (Input.GetKeyDown (KeyCode.Return))
        {
            GoToIntroLevel();
		}
	}

    void GoToIntroLevel()
    {
        AudioManager.Instance.GameStart();
		SceneManager.LoadScene ("intro", LoadSceneMode.Single);
    }
}
