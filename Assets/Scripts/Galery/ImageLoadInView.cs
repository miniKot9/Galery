public class ImageLoadInView : ImageLoader {

	private void Start()
	{
		gameObject.GetComponent<ImageLoader>().SetTexture(ViewPage.ImageNumberToView);
	}
}
