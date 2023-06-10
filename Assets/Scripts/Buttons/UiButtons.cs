using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class UiButtons : MonoBehaviour
{

	public void LoadViewScene()
	{
		ViewPage.ImageNumberToView = gameObject.GetComponent<ImageLoader>().ImageNumber;
		SceneManager.LoadScene(2);
	}

	public void LoadScene (int NumberOfScene)
	{
		StartCoroutine(LoadAsyncScene(NumberOfScene));
	}

	IEnumerator LoadAsyncScene (int NumberOfScene)
	{
		AsyncOperation operation = SceneManager.LoadSceneAsync(NumberOfScene);

		while (!operation.isDone)
		{
			yield return null;
		}
	}
}
