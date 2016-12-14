using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

	[SerializeField]
	private RectTransform scrollImageViewContent;

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

		scrollImageViewContent.rect.height = ((float)textures.Count) * sumbnaleHeight; 

		for(int i = 0; i < textures.Count; i++){
			GameObject image = new GameObject ("Sumbnale" + i.ToString());
			RectTransform rTransform = image.AddComponent<RectTransform> ();
			Image imageCOmponent = image.AddComponent<Image> ();


			imageCOmponent = textures [i];
		}
	}

}
