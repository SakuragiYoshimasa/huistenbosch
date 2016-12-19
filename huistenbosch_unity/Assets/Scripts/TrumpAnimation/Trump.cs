using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//
//attached Trump object, which is an empty object has two plane
//
public class Trump : MonoBehaviour {

	[SerializeField]
	private Texture2D image;
	public Texture2D Image {
		set{ image = value;}
		get{ return image;}
	}

	[SerializeField]
	private GameObject surface_front;
	[SerializeField]
	private GameObject surface_back;

	void OnEnable(){
        Image = TrumpManager.I.shapeTex;
		Material mat = new Material (Shader.Find("Custom/TrumpShader"));
		mat.SetTexture("_MainTex",ImageLoadManager.I.GetSortedTexture());
		mat.SetTexture("_ShapeTex",TrumpManager.I.shapeTex);

		surface_back.GetComponent<Renderer> ().material = mat;
		surface_front.GetComponent<Renderer> ().material = mat;
	}
}
