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
		Material mat = new Material (Shader.Find("Standard"));
		mat.color = Random.ColorHSV ();
			//new Color (Random.value, Random.value, Random.value);
		surface_back.GetComponent<Renderer> ().material = mat;
		surface_front.GetComponent<Renderer> ().material = mat;
	}

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
