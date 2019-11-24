using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManejadorEscenas : MonoBehaviour
{
	public GameObject UIRootObject;
	private AsyncOperation sceneAsync;

	void Start()
	{
		
	}
	private void Update()
	{
		if(Input.GetKeyDown("l"))
		{
			UIRootObject = GameObject.FindGameObjectWithTag("PLAYER");
			StartCoroutine(loadScene(2));
		}
	}
	public void CargarEscena()
	{
		UIRootObject = GameObject.FindGameObjectWithTag("PLAYER");
		StartCoroutine(loadScene(2));
	}

	IEnumerator loadScene(int index)
	{
		AsyncOperation scene = SceneManager.LoadSceneAsync(index, LoadSceneMode.Additive);
		scene.allowSceneActivation = false;
		sceneAsync = scene;

		//Wait until we are done loading the scene
		while (scene.progress < 0.9f)
		{
			Debug.Log("Loading scene " + " [][] Progress: " + scene.progress);
			yield return null;
		}
		sceneAsync.allowSceneActivation = true;
		while (!scene.isDone)
		{
			// wait until it is really finished
			yield return null;
		}
		OnFinishedLoadingAllScene();
	}

	void enableScene(int index)
	{
		//Activate the Scene
		sceneAsync.allowSceneActivation = true;


		Scene sceneToLoad = SceneManager.GetSceneByBuildIndex(index);
		if (sceneToLoad.IsValid())
		{
			Debug.Log("Scene is Valid");
			SceneManager.MoveGameObjectToScene(UIRootObject, sceneToLoad);
			SceneManager.SetActiveScene(sceneToLoad);
		}
	}

	void OnFinishedLoadingAllScene()
	{
		Debug.Log("Done Loading Scene");
		enableScene(2);
		SceneManager.UnloadSceneAsync(1);
		UIRootObject.transform.position = new Vector3(0f,0.5f,1.85f);
		Debug.Log("Scene Activated!");
	}

}
