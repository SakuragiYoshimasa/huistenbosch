using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class preRenderMovie : MonoBehaviour {

    [SerializeField]
    MovieTexture movieTexture;

    [SerializeField]
    preRenderSourceCamera cam;

	void Start () {
		
	}
	
	void Update () {
		
	}

    public void StartPreRenderedMovie() {
        Debug.Log("StartMovie");
        movieTexture = ((MovieTexture)GetComponent<Renderer>().material.mainTexture);
        movieTexture.Play();
        cam.source = movieTexture;
    }
}
