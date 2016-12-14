using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

	[SerializeField]
	private RectTransform scrollImageViewContent;

	[SerializeField]
	private Transform scrollImageViewContentTransform;

	[SerializeField]
	private int scrollImageViewHorizontalImageNum;

	[SerializeField]
	private RectTransform scrollImageViewRectTransform;

	[SerializeField]
	private float sumbnaleWidth;

	[SerializeField]
	private float sumbnaleHeight;

	public void LoadImages(){
		MainConrtroller.I.LoadImages ();
	}
	public void StartMovieSplitIntoTwo(){
		MainConrtroller.I.StartMovieSplitIntoTwo ();
	}
	public void StartMovieSplitIntoThree(){
		MainConrtroller.I.StarrMovieSplitIntoThree ();
	}

	public void UpdateScrollImageViewContent(){
		List<Texture2D> textures = ImageLoadManager.I.GetTextures ();

		scrollImageViewRectTransform.sizeDelta = new Vector2 (sumbnaleWidth * (float)scrollImageViewHorizontalImageNum, 500);
		scrollImageViewContent.sizeDelta = new Vector2 (0, sumbnaleHeight * (float)(textures.Count / scrollImageViewHorizontalImageNum + 1));

		for(int i = 0; i < textures.Count; i++){
			GameObject image = new GameObject ("Sumbnale" + i.ToString());

			image.transform.parent = scrollImageViewContentTransform;
	
			RectTransform rTransform = image.AddComponent<RectTransform> ();
			rTransform.anchoredPosition = new Vector3 (0 ,0, 0);
			rTransform.anchorMin = new Vector2 (0, 1);
			rTransform.anchorMax = new Vector2 (0, 1);
			rTransform.pivot = new Vector2 (0, 0);
			rTransform.sizeDelta = new Vector2 (150, 150);
			rTransform.localPosition = new Vector3 (
				(float)(i % scrollImageViewHorizontalImageNum) * sumbnaleHeight, 
				-150f - sumbnaleHeight * (float)(i / scrollImageViewHorizontalImageNum), 
				0
			);

			image.AddComponent<Image> ().sprite = Sprite.Create(textures[i], new Rect(0,0,256,256), Vector2.zero);
		}
	}
}
