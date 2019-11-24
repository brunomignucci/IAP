using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManejadorEscenas : MonoBehaviour
{
	private GameObject player;
	private AsyncOperation sceneAsync;

	void Start()
	{
		
	}
	private void Update()
	{
		
	}
	public void CargarEscena(int i, GameObject go)
	{
		player = go;
		StartCoroutine(loadScene(i));
	}

	public void CargarEscena(string sceneName, GameObject go)
	{
		player = go;
		StartCoroutine(loadScene(sceneName));
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
	IEnumerator loadScene(string sceneName)
	{
		AsyncOperation scene = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
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
			SceneManager.MoveGameObjectToScene(player, sceneToLoad);
			SceneManager.SetActiveScene(sceneToLoad);
		}
	}

	void OnFinishedLoadingAllScene()
	{
		Debug.Log("Done Loading Scene");
		enableScene(2);
		SceneManager.UnloadSceneAsync(1);
		player.transform.position = new Vector3(0f,0.5f,1.85f);
		Debug.Log("Scene Activated!");
	}

}
