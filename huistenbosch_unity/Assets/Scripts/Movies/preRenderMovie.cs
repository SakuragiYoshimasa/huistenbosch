using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class preRenderMovie : MonoBehaviour {

    [SerializeField]
    MovieTexture movieTexture;
    [SerializeField]
    preRenderSourceCamera cam;

    public void StartPreRenderedMovie() {
        Debug.Log("StartPreRenderedMovie");
        movieTexture = ((MovieTexture)GetComponent<Renderer>().material.mainTexture);
        movieTexture.Play();
        cam.source = movieTexture;
    }

    public void StopPreRenderedMovie() {
        movieTexture.Stop();
    }
}
