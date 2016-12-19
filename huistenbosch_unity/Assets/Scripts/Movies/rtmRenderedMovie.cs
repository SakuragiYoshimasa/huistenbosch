using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rtmRenderedMovie : MonoBehaviour {

    [SerializeField]
    GameObject animationComponent;

    public void StartRLTRenderingMovie()
    {
        Debug.Log("StartRLTRenderingMovie");
        animationComponent.SetActive(true);
    }

    public void StopRLTRenderingMovie() {
        animationComponent.SetActive(false);
    }
}
