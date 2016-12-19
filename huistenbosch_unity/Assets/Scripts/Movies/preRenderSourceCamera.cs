using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class preRenderSourceCamera : MonoBehaviour {

    [SerializeField]
    public MovieTexture source;

    void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        if (source != null) {
            Graphics.Blit(source, dest);
        }
    }
}
