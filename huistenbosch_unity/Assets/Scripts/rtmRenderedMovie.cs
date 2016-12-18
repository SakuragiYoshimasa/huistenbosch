using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rtmRenderedMovie : MonoBehaviour {

    [SerializeField]
    GameObject animationComponent;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartRLTRenderingMovie()
    {
        Debug.Log("StartMovie");
        animationComponent.SetActive(true);
    }

    public void StopRLTRenderingMovie() {
        animationComponent.SetActive(false);
    }
}
