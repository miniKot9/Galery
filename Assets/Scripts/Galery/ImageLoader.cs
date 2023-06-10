using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ImageLoader : MonoBehaviour
{

    public int ImageNumber { get; private set; } = 1;

    public void SetTexture(int NumberOfImage)
	{
        StartCoroutine(GetTexture(NumberOfImage));
	}

	private IEnumerator GetTexture(int NumberOfImage)
    {
        ImageNumber = NumberOfImage;
        UnityWebRequest _unityWebRequest = UnityWebRequestTexture.GetTexture("http://data.ikppbb.com/test-task-unity-data/pics/" + NumberOfImage + ".jpg");
        yield return _unityWebRequest.SendWebRequest();

        Texture2D myTexture = DownloadHandlerTexture.GetContent(_unityWebRequest);
        Rect rec = new Rect(0, 0, myTexture.width, myTexture.height);
        gameObject.GetComponent<Image>().sprite =  Sprite.Create(myTexture,rec, new Vector2(0, 0), 1);
    }
}
