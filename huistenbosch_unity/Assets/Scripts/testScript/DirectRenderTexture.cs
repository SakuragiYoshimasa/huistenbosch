using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectRenderTexture : MonoBehaviour {

    public RenderTexture source;

    void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        if (source != null)
        {
            Graphics.Blit(source, dest);
        }
    }
}
