using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

	#region ActiveControllObjects
	[SerializeField]
	private GameObject[] menuObjects;
	[SerializeField]
	private GameObject[] previewObjects;
	#endregion


	#region ScrollViewFields
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
	[SerializeField]
	private List<bool> selecedStates; 
	[SerializeField]
	private Color selectedColor;
	#endregion

	#region ButtonEvent
	public void LoadImages(){
		MainConrtroller.I.LoadImages ();
	}
	public void StartMovieSplitIntoTwo(){
		MainConrtroller.I.StartMovieSplitIntoTwo ();
	}
	public void StartMovieSplitIntoThree(){
		MainConrtroller.I.StarrMovieSplitIntoThree ();
	}
	public void RemoveSelectedTextures(){
		MainConrtroller.I.RemoveSelectedTextures (selecedStates);
		UpdateScrollImageViewContent ();
	}

	public void StopPlay(){
		MainConrtroller.I.StopPlay ();
	}
	#endregion

	#region ScrollViewFunctions
	public void UpdateScrollImageViewContent(){

		for( int i=0; i < scrollImageViewContentTransform.childCount; ++i ){
			GameObject.Destroy( scrollImageViewContentTransform.GetChild( i ).gameObject );
		}

		List<Texture2D> textures = ImageLoadManager.I.GetTextures ();
		selecedStates = new List<bool>(0);

		scrollImageViewRectTransform.sizeDelta = new Vector2 (sumbnaleWidth * (float)scrollImageViewHorizontalImageNum, 500);
		scrollImageViewContent.sizeDelta = new Vector2 (0, sumbnaleHeight * (float)(textures.Count / scrollImageViewHorizontalImageNum + 1));

		for(int i = 0; i < textures.Count; i++){
			GameObject image = new GameObject ("Sumbnale" + i.ToString());
			selecedStates.Add (false);

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

			Image imageComponent = image.AddComponent<Image> ();
			imageComponent.sprite = Sprite.Create(textures[i], new Rect(0,0,256,256), Vector2.zero);

			Button buttomComponent = image.AddComponent<Button> ();
			AddButtonEvent (buttomComponent, imageComponent, i);

		}
	}
	public void ChangeSelectedState(Image imageComponent, int index){
		Debug.Log ("SelecedStatesSize : " + selecedStates.Count.ToString());
		Debug.Log ("index:" + index.ToString());
		selecedStates [index] = !selecedStates [index];

		if (selecedStates [index]) {
			imageComponent.color = selectedColor;
		} else {
			imageComponent.color = Color.white;
		}
	} 
	public void AddButtonEvent(Button button,Image imageComponent ,int index) {
		button.onClick.AddListener(() => {
			ChangeSelectedState(imageComponent, index);
		});
	}
	#endregion

	void Start(){
		switchToMenuMode ();
	}

	#region SwitchGUIMode
	public void switchToMenuMode(){
		foreach(GameObject go in menuObjects){
			go.SetActive (true);
		}

		foreach(GameObject go in previewObjects){
			go.SetActive (false);
		}
	}
	public void switchToPlayingMode(){
		foreach(GameObject go in menuObjects){
			go.SetActive (false);
		}

		foreach (GameObject go in previewObjects) {
			go.SetActive (true);
		}
	}

	#endregion
}
