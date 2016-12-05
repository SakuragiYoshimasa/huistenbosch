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
		Material mat = new Material (Shader.Find("Custom/TrumpShader"));
		//mat.color = Random.ColorHSV ();
		mat.SetTexture("_MainTex",ImageLoadManager.I.GetRandomTexture ());
		mat.SetTexture("_ShapeTex",TrumpManager.I.shapeTex);

		//new Color (Random.value, Random.value, Random.value);
		surface_back.GetComponent<Renderer> ().material = mat;
		surface_front.GetComponent<Renderer> ().material = mat;
	}
}
