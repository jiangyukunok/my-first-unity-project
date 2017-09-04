using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public void LoadNextScene()
	{
		int currentIndex = SceneManager.GetActiveScene().buildIndex;
		print(currentIndex);
		SceneManager.LoadScene(currentIndex + 1);
	}
}
