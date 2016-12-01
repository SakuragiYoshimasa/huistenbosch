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
		

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
