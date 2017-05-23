using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string sceneName){
		Debug.Log("Level load requested for: " + sceneName);
		SceneManager.LoadScene(sceneName);
	}

	public void LoadNextLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		print("Load next level");
	}

	public void Quit(){
		Debug.Log("Quit Application");

        #if UNITY_WEBPLAYER
            public static string webplayerQuitURL = "http://google.com";
        #endif

        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #elif UNITY_WEBPLAYER
            Application.OpenURL(webplayerQuitURL);
        #else
            Application.Quit();
        #endif
    }

}
