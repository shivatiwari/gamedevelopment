using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	public string leveltoLoad = "MainMenu";
	// Use this for initialization
	public void Exit ()
	{
		SceneManager.LoadScene (leveltoLoad);
	}

}