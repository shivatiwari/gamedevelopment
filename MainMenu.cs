
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public string levelToLoad = "MainLevel";
	public string levelToLoad2 = "Credits";
	// Use this for initialization
	public void Play ()
	{
		SceneManager.LoadScene (levelToLoad);
	}
	public void Credits ()
	{
		SceneManager.LoadScene (levelToLoad2);
	}
	public void Quit ()
	{
		Debug.Log ("Exit");
		Application.Quit ();
	}
}