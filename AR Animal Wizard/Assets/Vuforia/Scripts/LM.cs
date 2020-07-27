using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LM : MonoBehaviour {

	public void Exit(){
		Application.Quit ();
	}


	public GameObject LoadingScreen;
	public Slider slider;
	public Text percentage;


	public void LoadLevel (int sceneIndex){
		StartCoroutine(LoadAsynchronously(sceneIndex));
	}
	IEnumerator LoadAsynchronously(int sceneIndex)
	{
		AsyncOperation operation = SceneManager.LoadSceneAsync (sceneIndex);

		LoadingScreen.SetActive (true);


		while (!operation.isDone) {
			int progress =(int) Mathf.Clamp01 (operation.progress / .9f);
			slider.value = progress;
			percentage.text= progress* 100 +"%"; 
			yield return null;
		}
	}


}
