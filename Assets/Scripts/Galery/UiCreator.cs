using UnityEngine.UI;
using UnityEngine;

public class UiCreator : MonoBehaviour
{
	[SerializeField] private int _imagesCount;
	[SerializeField] private GameObject _prefabImageContainer;
	[SerializeField] private GameObject _contentObject;

	private float _gridLayaut;

	private void Start()
	{
		_gridLayaut = _contentObject.GetComponent<GridLayoutGroup>().cellSize.x;

		int StartImageCount = 8;
		if (StartImageCount > _imagesCount)
			StartImageCount = _imagesCount;

		for (int i = 0; i < StartImageCount; i++)
		{
			GameObject NewImage = Instantiate(_prefabImageContainer, _contentObject.transform);
			NewImage.GetComponent<ImageLoader>().SetTexture(i +1);
		}
	}

	public void NewImageLoad()
	{
		if (_contentObject.transform.childCount >= _imagesCount) return;
		
		float ContentPositionY = _contentObject.GetComponent<RectTransform>().localPosition.y;

		if (_contentObject.GetComponent<RectTransform>().localPosition.y + _gridLayaut*4 > _contentObject.transform.childCount* _gridLayaut/2)
		{
			_contentObject.GetComponent<RectTransform>().sizeDelta = new Vector2(_contentObject.GetComponent<RectTransform>().sizeDelta.x,
																				_contentObject.transform.childCount * _gridLayaut /2 + _gridLayaut);

			GameObject NewImage = Instantiate(_prefabImageContainer, _contentObject.transform);
			NewImage.GetComponent<ImageLoader>().SetTexture(_contentObject.transform.childCount);
		}
	}
}
